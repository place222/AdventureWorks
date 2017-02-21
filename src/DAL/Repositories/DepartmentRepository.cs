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
        public async Task<PageDomain<Department>> GetDepartmentsByPageAsync(int start, int length, string search)
        {
            var model = new PageDomain<Department>();
            string where = @" WHERE 1=1 ";
            if (!string.IsNullOrWhiteSpace(search))
            {
                where += @"AND Name LIKE @Search";
            }
            string sql = @"SELECT * FROM HumanResources.Department " +
            where + @" ORDER BY DepartmentID DESC OFFSET @OFFSET ROWS FETCH NEXT @FETCH ROWS ONLY;";
            var countSql = @"SELECT COUNT(*) FROM HumanResources.Department" + where + @";";
            var p = new DynamicParameters();
            p.Add("@OFFSET", start, DbType.Int32);
            p.Add("@FETCH", length, DbType.Int32);
            p.Add("@Search", $"%{search}%", DbType.String);
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                using (var multi = await conn.QueryMultipleAsync(sql + countSql, p))
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

        public async Task AddDepartmentAsync(Department department)
        {
            var sql = @"INSERT INTO HumanResources.Department
                                ( Name, GroupName, ModifiedDate )
                        VALUES  ( @Name, -- Name - Name
                                  @GroupName, -- GroupName - Name
                                  GETDATE()  -- ModifiedDate - datetime
                                  )";
            var p = new DynamicParameters();
            p.Add("@Name", department.Name, DbType.String);
            p.Add("@GroupName", department.GroupName, DbType.String);
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                var result = await conn.ExecuteAsync(sql, p);
                if (result != 1)
                    throw new Exception("插入错误!");
            }
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            var sql = @"UPDATE HumanResources.Department SET Name = @Name,GroupName=@GroupName WHERE DepartmentID =@id";
            var p = new DynamicParameters();
            p.Add("@Name", department.Name, DbType.String);
            p.Add("@GroupName", department.GroupName, DbType.String);
            p.Add("@id", department.DepartmentID, DbType.Int32);
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                var result = await conn.ExecuteAsync(sql, p);
                if (result != 1)
                    throw new Exception("更新错误!");
            }
        }
    }
}
