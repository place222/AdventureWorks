using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.DomainModels;
using DAL.DomainModels.ProductModels;
using DAL.Entities.Production;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;

namespace DAL.Repositories
{
    public class ProductModelRepository : IProductModelRepository
    {
        public ConnectionOptions Options { get; }

        public ProductModelRepository(IOptions<ConnectionOptions> options)
        {
            Options = options.Value;
        }
        /// <summary>
        /// 产品型号分页数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 型号的详情
        /// </summary>
        /// <param name="productModelId"></param>
        /// <returns></returns>
        public async Task<ProductModelDetailDoamin> GetProductModelDetailByIdAsync(int productModelId)
        {
            var model = new ProductModelDetailDoamin();
            var sql = @"SELECT ProductModelID ,
                               Name ,
                               CatalogDescription ,
                               Instructions 
                        FROM Production.ProductModel 
                        WHERE ProductModelID = @id;";
            sql += @"SELECT Illustration.IllustrationID ,
                            Diagram
                    FROM Production.ProductModelIllustration 
                    JOIN Production.Illustration ON Illustration.IllustrationID = ProductModelIllustration.IllustrationID
                    WHERE ProductModelID = @id;";
            sql += @"SELECT ProductDescription.ProductDescriptionID ,
                           Description 
                    FROM Production.ProductModelProductDescriptionCulture
                    JOIN Production.ProductDescription 
                    ON ProductDescription.ProductDescriptionID = ProductModelProductDescriptionCulture.ProductDescriptionID
                    WHERE ProductModelID = @id AND CultureID = N'zh-cht';";
            var p = new DynamicParameters();
            p.Add("@id", productModelId, DbType.Int32);
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                using (var multi = await conn.QueryMultipleAsync(sql, p))
                {
                    model.ProductModel = await multi.ReadFirstOrDefaultAsync<ProductModel>();
                    model.Illustrations = await multi.ReadAsync<Illustration>();
                    model.ProductDescription = await multi.ReadFirstOrDefaultAsync<ProductDescription>();
                }
            }
            return model;
        }
    }
}
