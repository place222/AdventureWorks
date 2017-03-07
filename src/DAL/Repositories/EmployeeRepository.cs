using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.DomainModels;
using DAL.DomainModels.Employees;
using DAL.Entities.HumanResources;
using DAL.Entities.Person;
using DAL.Identity;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;

namespace DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IOptions<ConnectionOptions> _connectionOptions;

        public EmployeeRepository(IOptions<ConnectionOptions> connectionOptions)
        {
            _connectionOptions = connectionOptions;
        }

        public async Task<bool> IsUserIsEmployee(User user)
        {
            var sql = "SELECT COUNT(1) FROM HumanResources.Employee WHERE BusinessEntityID = @id";
            var p = new DynamicParameters();
            p.Add("@id", user.Id, DbType.Int32);
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                return await conn.ExecuteScalarAsync<bool>(sql, p);
            }
        }

        public async Task<PageDomain<EmployeeDomain>> GetEmployeesByPageAsync(int start, int length)
        {
            var model = new PageDomain<EmployeeDomain>();

            var sql = @"SELECT 
                        HumanResources.Employee.BusinessEntityID AS Id,
                        HireDate,
                        CurrentFlag,
                        FirstName+ ' '+MiddleName+' '+LastName AS Name
                        FROM Person.Person JOIN HumanResources.Employee 
                        ON Employee.BusinessEntityID = Person.BusinessEntityID
                        ORDER BY HumanResources.Employee.BusinessEntityID DESC
                        OFFSET @OFFSET ROWS FETCH NEXT @FETCH ROWS ONLY;
                        SELECT COUNT(*) FROM HumanResources.Employee;
                        ";
            var p = new DynamicParameters();
            p.Add("@OFFSET", start, DbType.Int32);
            p.Add("@FETCH", length, DbType.Int32);
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                using (var multi = await conn.QueryMultipleAsync(sql, p))
                {
                    model.Data = (await multi.ReadAsync<EmployeeDomain>()).ToList();
                    model.TotalRecord = await multi.ReadFirstOrDefaultAsync<int>();
                }
            }
            return model;
        }

        public async Task<EmployeeDetailDomain> GetEmployeeDetailByIdAsync(int employeeId)
        {
            var model = new EmployeeDetailDomain();
            var sql = @"SELECT 
                        PersonType,
                        FirstName+' '+MiddleName+' '+LastName AS Name,
                        EmailPromotion,
                        NationalIDNumber,
                        LoginID,
                        JobTitle,
                        BirthDate,
                        MaritalStatus,
                        Gender,
                        HireDate,
                        SalariedFlag,
                        VacationHours,
                        SickLeaveHours,
                        CurrentFlag
                        FROM Person.Person JOIN HumanResources.Employee 
                        ON Employee.BusinessEntityID = Person.BusinessEntityID 
                        WHERE Employee.BusinessEntityID = @id;";
            sql += @"SELECT * FROM Person.EmailAddress WHERE BusinessEntityID=@id;";
            sql += @"SELECT AddressLine1 ,
                           AddressLine2 ,
                           City,
                            SpatialLocation,
	                       PostalCode , 
                           StateProvince.StateProvinceID,
	                       StateProvinceCode,
	                       StateProvince.Name AS StateProvinceName,
	                       IsOnlyStateProvinceFlag,
	                       TerritoryID,
	                       AddressType.AddressTypeID,
                           AddressType.Name AS AddressTypeName,
	                       CountryRegion.CountryRegionCode,
	                       CountryRegion.Name AS CountryRegionName
                    FROM Person.Address 
                    JOIN Person.BusinessEntityAddress 
                    ON BusinessEntityAddress.AddressID = Address.AddressID
                    JOIN Person.AddressType 
                    ON AddressType.AddressTypeID = BusinessEntityAddress.AddressTypeID
                    JOIN Person.StateProvince 
                    ON StateProvince.StateProvinceID = Address.StateProvinceID
                    JOIN Person.CountryRegion 
                    ON CountryRegion.CountryRegionCode = StateProvince.CountryRegionCode
                    WHERE BusinessEntityID = @id;";
            sql += @"SELECT Name ,
                            PhoneNumber ,
                            PersonPhone.PhoneNumberTypeID
                    FROM Person.PersonPhone JOIN Person.PhoneNumberType 
                    ON PhoneNumberType.PhoneNumberTypeID = PersonPhone.PhoneNumberTypeID
                    WHERE BusinessEntityID = @id;";
            sql += @"SELECT BusinessEntityID ,
                           BusinessEntityContact.ContactTypeID ,
                           PersonID ,
                           Name 
                    FROM Person.BusinessEntityContact
                    JOIN Person.ContactType ON ContactType.ContactTypeID = BusinessEntityContact.ContactTypeID
                    WHERE BusinessEntityID = @id;";
            var p = new DynamicParameters();
            p.Add("@id", employeeId, DbType.Int32);
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                using (var multi = await conn.QueryMultipleAsync(sql, p))
                {
                    model.EmployeeInfo = await multi.ReadFirstOrDefaultAsync<EmployeeInfoDomain>();
                    model.EmployeeEmailAddresses = await multi.ReadAsync<EmailAddresses>();
                    model.EmployeeAddresses = await multi.ReadAsync<EmployeeAddressDomain>();
                    model.EmployeePhones = await multi.ReadAsync<EmployeePhoneDomain>();
                    model.EmployeeContacts = await multi.ReadAsync<EmployeeContactDomain>();
                }
            }
            return model;
        }
    }
}
