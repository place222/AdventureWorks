using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.DomainModels;
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

        public async Task<EmployeeDetail> GetEmployeeDetailById(int id)
        {
            var sql = @"SELECT BirthDate ,
                               BusinessEntityID ,
                               JobTitle ,
                               LoginID ,
                               MaritalStatus ,
                               NationalIDNumber
                        FROM HumanResources.Employee WHERE BusinessEntityID = @id ";
            var p = new DynamicParameters();
            p.Add("@id", id, DbType.Int32);
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                return await conn.QueryFirstOrDefaultAsync<EmployeeDetail>(sql, p);
            }
        }
    }
}
