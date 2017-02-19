using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.DomainModels;
using DAL.DomainModels.Departments;
using DAL.Entities.HumanResources;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;

namespace DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public ConnectionOptions Options { get; }

        public DepartmentRepository(IOptions<ConnectionOptions> connectionOptions)
        {
            Options = connectionOptions.Value;
        }
        public async Task<PageDomain<Department>> GetDepartmentsByPageAsync(int start, int length)
        {
            var model = new PageDomain<Department>();
            string sql = @"SELECT * FROM HumanResources.Department ORDER BY DepartmentID DESC OFFSET @OFFSET ROWS FETCH NEXT @FETCH ROWS ONLY;
                           SELECT COUNT(*) FROM HumanResources.Department;";
            var p = new DynamicParameters();
            p.Add("@OFFSET", start, DbType.Int32);
            p.Add("@FETCH", length, DbType.Int32);
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                using (var multi = await conn.QueryMultipleAsync(sql, p))
                {
                    model.Data = (await multi.ReadAsync<Department>()).ToList();
                    model.TotalRecord = await multi.ReadFirstOrDefaultAsync<int>();
                }
            }
            return model;
        }

        public async Task<IEnumerable<GroupDomain>> GetGroupsAsync()
        {
            string sql = @"SELECT
                            GroupName
                            FROM HumanResources.Department
                            GROUP BY GroupName";
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                return await conn.QueryAsync<GroupDomain>(sql);
            }
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            var sql = @"SELECT * FROM HumanResources.Department WHERE DepartmentID = @id";
            var p = new DynamicParameters();
            p.Add("@id", departmentId, DbType.Int32);
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                return await conn.QueryFirstOrDefaultAsync<Department>(sql, p);
            }
        }

        public async Task DeleteDepartmentByIdAsync(int departmentId)
        {
            var sql = @"DELETE HumanResources.Department WHERE DepartmentID = @id";
            var p = new DynamicParameters();
            p.Add("@id", departmentId, DbType.Int32);
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                await conn.ExecuteAsync(sql, p);
            }
        }
    }
}
