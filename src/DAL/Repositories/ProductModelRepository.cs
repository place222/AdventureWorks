using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.DomainModels;
using DAL.Entities.Production;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;

namespace DAL.Repositories
{
    public class ProductModelRepository : IProductModelRepository
    {
        public ConnectionOptions Options { get;}

        public ProductModelRepository(IOptions<ConnectionOptions> options )
        {
            Options = options.Value;
        }
        public async Task<PageDomain<ProductModel>> GetProductModelsByPageAsync(int start, int length)
        {
            var model = new PageDomain<ProductModel>();
            var sql = @"SELECT ProductModelID ,
                               Name ,
                               CatalogDescription ,
                               Instructions ,
                               ModifiedDate
                        FROM Production.ProductModel 
                        ORDER BY ProductModelID DESC OFFSET @OFFSET ROWS FETCH NEXT @FETCH ROWS ONLY;";
            sql += @"SELECT COUNT(*) FROM Production.ProductModel;";
            var p = new DynamicParameters();
            p.Add("@OFFSET", start, DbType.Int32);
            p.Add("@FETCH", length, DbType.Int32);
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                using (var multi = await conn.QueryMultipleAsync(sql, p))
                {
                    model.Data = await multi.ReadAsync<ProductModel>();
                    model.TotalRecord = await multi.ReadFirstOrDefaultAsync<int>();
                }
            }
            return model;
        }
    }
}
