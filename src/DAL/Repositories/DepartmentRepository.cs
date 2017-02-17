using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.DomainModels;
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
        public async Task<IEnumerable<Department>> GetDepartmentsByPage(IPageInput input)
        {
            string sql = "SELECT * FROM HumanResources.Department ORDER BY DepartmentID DESC OFFSET @OFFSET ROWS FETCH NEXT @FETCH ROWS ONLY";
            var p = new DynamicParameters();
            p.Add("@OFFSET", (input.PageNumber - 1) * input.PageSize, DbType.Int32);
            p.Add("@FETCH", input.PageSize, DbType.Int32);
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                return await conn.QueryAsync<Department>(sql, p);
            }
        }
    }
}
