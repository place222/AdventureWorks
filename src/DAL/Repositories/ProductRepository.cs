using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.DomainModels;
using DAL.DomainModels.Products;
using DAL.Entities.Production;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IOptions<ConnectionOptions> _connectionOptions;

        public ProductRepository(IOptions<ConnectionOptions> connectionOptions)
        {
            _connectionOptions = connectionOptions;
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            IEnumerable<ProductCategory> categories = null;
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                categories = conn.Query<ProductCategory>("SELECT * FROM Production.ProductCategory");
            }
            return categories;
        }

        public IEnumerable<ProductSubcategory> GetProductSubcategoriesByCategoryId(int id)
        {
            IEnumerable<ProductSubcategory> categories = null;
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                categories = conn.Query<ProductSubcategory>("SELECT * FROM Production.ProductSubcategory WHERE ProductCategoryID = @id", new { id = id });
            }
            return categories;
        }

        public IEnumerable<UnionCategoryModel> GetCategoryTreeModels()
        {
            IEnumerable<UnionCategoryModel> categories = null;
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                categories = conn.Query<UnionCategoryModel>(@"SELECT ProductCategoryID,0 AS ProductSubcategoryID,Name FROM Production.ProductCategory UNION ALL SELECT ProductCategoryID, ProductSubcategoryID, Name FROM Production.ProductSubcategory");
            }
            return categories;
        }

        public IEnumerable<Product> GetProductsBySubCategoryId(int id)
        {
            IEnumerable<Product> categories = null;
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                categories = conn.Query<Product>("SELECT * FROM Production.Product WHERE ProductSubcategoryID = @id", new { id = id });
            }
            return categories;
        }

        public IEnumerable<ProductWithPhotoModel> GetProductsBySubCategoryIdWithPhoto(int id)
        {
            IEnumerable<ProductWithPhotoModel> categories = null;
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                categories = conn.Query<ProductWithPhotoModel>(@"SELECT Product.ProductID,
       Name,
       ProductNumber,
       MakeFlag,
       FinishedGoodsFlag,
       Color,
       SafetyStockLevel,
       ReorderPoint,
       StandardCost,
       ListPrice,
       Size,
       SizeUnitMeasureCode,
       WeightUnitMeasureCode,
       Weight,
       DaysToManufacture,
       ProductLine,
       Class,
       Style,
       ProductSubcategoryID,
       ProductModelID,
       SellStartDate,
       SellEndDate,
       DiscontinuedDate,
       ProductPhoto.ProductPhotoID,
       ThumbNailPhoto,
       ThumbnailPhotoFileName,
       LargePhoto,
       LargePhotoFileName FROM Production.Product LEFT JOIN Production.ProductProductPhoto ON ProductProductPhoto.ProductID = Product.ProductID
JOIN Production.ProductPhoto ON ProductPhoto.ProductPhotoID = ProductProductPhoto.ProductPhotoID WHERE ProductSubcategoryID = @id", new { id = id });
            }
            return categories;

        }

        public Product GetProductById(int id)
        {
            Product product = null;
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                product = conn.QueryFirstOrDefault<Product>("SELECT * FROM Production.Product WHERE ProductID = @id", new { id = id });
            }
            return product;
        }

        /// <summary>
        /// 后台产品页列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public async Task<PageDomain<ProductDomain>> GetProductsByPageAsync(int start, int length)
        {
            //TODO::没有图片的话就有BUG了
            var model = new PageDomain<ProductDomain>();
            var sql = @"SELECT MakeFlag ,
	                           ProductNumber,
                               FinishedGoodsFlag ,
                               Name ,
                               Product.ProductID ,
                               ThumbNailPhoto
                        FROM Production.Product JOIN Production.ProductProductPhoto 
                        ON ProductProductPhoto.ProductID = Product.ProductID
                        JOIN Production.ProductPhoto ON ProductPhoto.ProductPhotoID = ProductProductPhoto.ProductPhotoID
                        WHERE [Primary] = 1
                        ORDER BY Production.Product.ProductID DESC
                        OFFSET @OFFSET ROWS FETCH NEXT @FETCH ROWS ONLY;";
            sql += @"SELECT COUNT(*) FROM Production.Product;";
            var p = new DynamicParameters();
            p.Add("@OFFSET", start, DbType.Int32);
            p.Add("@FETCH", length, DbType.Int32);
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                using (var multi = await conn.QueryMultipleAsync(sql, p))
                {
                    model.Data = await multi.ReadAsync<ProductDomain>();
                    model.TotalRecord = await multi.ReadFirstOrDefaultAsync<int>();
                }
            }

            return model;
        }
        /// <summary>
        /// 查看产品详情
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ProductDetailDomain> GetProdutDetailByIdAsync(int productId)
        {
            var model = new ProductDetailDomain();
            var sql = @"SELECT Class ,
                               Color ,
                               DaysToManufacture ,
                               DiscontinuedDate ,
                               FinishedGoodsFlag ,
                               ListPrice ,
                               MakeFlag ,
                               Product.Name ,
                               ProductSubcategory.Name AS ProductSubcategoryName,
                               size.Name AS SizeUnitMeasureCodeName,
                               weight.Name AS WeightUnitMeasureCodeName,
                               ProductID ,
                               ProductLine ,
                               ProductModelID ,
                               ProductNumber ,
                               Product.ProductSubcategoryID ,
                               ReorderPoint ,
                               SafetyStockLevel ,
                               SellEndDate ,
                               SellStartDate ,
                               Size ,
                               SizeUnitMeasureCode ,
                               StandardCost ,
                               Style ,
                               Weight ,
                               WeightUnitMeasureCode 
                        FROM Production.Product
                        LEFT JOIN Production.ProductSubcategory ON ProductSubcategory.ProductSubcategoryID = Product.ProductSubcategoryID
                        LEFT JOIN Production.UnitMeasure AS size ON size.UnitMeasureCode = Product.SizeUnitMeasureCode
                        LEFT JOIN Production.UnitMeasure AS weight ON weight.UnitMeasureCode = Product.WeightUnitMeasureCode
                        WHERE ProductID = @id;";
            sql += @"SELECT ProductID,
                            LargePhoto ,
                            ProductPhoto.ProductPhotoID 
                    FROM Production.ProductProductPhoto 
                    JOIN Production.ProductPhoto ON ProductPhoto.ProductPhotoID = ProductProductPhoto.ProductPhotoID
                    WHERE ProductID = @id;";
            sql += @"SELECT ProductID ,
                           StandardCost ,
                           StartDate ,
                           EndDate 
                    FROM Production.ProductCostHistory
                    WHERE ProductID = @id;";
            sql += @"SELECT Comments ,
                           EmailAddress ,
                           ProductID ,
                           ProductReviewID ,
                           Rating ,
                           ReviewDate ,
                           ReviewerName
                    FROM Production.ProductReview 
                    WHERE ProductID = @id;";
            sql += @"SELECT ProductID ,
                           StartDate ,
                           EndDate ,
                           ListPrice 
                    FROM Production.ProductListPriceHistory 
                    WHERE ProductID = @id;";
            sql += @"SELECT ProductID ,
                           ProductInventory.LocationID ,
                           Shelf ,
                           Bin ,
                           Quantity ,
                           Name ,
                           CostRate ,
                           Availability
                    FROM Production.ProductInventory
                    JOIN Production.Location 
                    ON Location.LocationID = ProductInventory.LocationID
                    WHERE ProductID = @id;";
            var p = new DynamicParameters();
            p.Add("@id", productId, DbType.Int32);
            using (var conn = new SqlConnection(_connectionOptions.Value.AdventureWorkConnection))
            {
                using (var multi = await conn.QueryMultipleAsync(sql, p))
                {
                    model.ProductInfo = await multi.ReadFirstOrDefaultAsync<ProductInfoDomain>();
                    model.ProductPhotos = await multi.ReadAsync<ProductPhoto>();
                    model.ProductCostHistories = await multi.ReadAsync<ProductCostHistory>();
                    model.ProductReviews = await multi.ReadAsync<ProductReview>();
                    model.ProductListPriceHistories = await multi.ReadAsync<ProductListPriceHistory>();
                    model.ProductInventories = await multi.ReadAsync<ProductInventoryDomain>();
                }
            }
            /*查找产品的文档tree
             * SELECT DISTINCT * FROM (
SELECT pd.ProductID ,
       ni.ji ,
       ni.DocumentLevel ,
       ni.Title ,
       ni.Owner ,
       ni.FolderFlag ,
       ni.FileName ,
       ni.FileExtension ,
       ni.Revision ,
       ni.ChangeNumber ,
       ni.Status ,
       ni.DocumentSummary ,
       ni.Document
FROM Production.ProductDocument AS pd
CROSS APPLY (SELECT dd.DocumentNode.ToString() AS ji,* FROM Production.Document AS dd
 WHERE pd.DocumentNode.IsDescendantOf(dd.DocumentNode) = 1 ) AS ni 
 WHERE pd.ProductID = 506) AS d
             */
            return model;
        }
    }
}
