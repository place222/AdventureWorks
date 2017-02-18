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
    }
}
