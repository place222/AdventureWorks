using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.DomainModels;
using DAL.Entities.Production;

namespace DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connstr =
            "Server=LIUYANG;Database=AdventureWorks2012;Trusted_Connection=True;MultipleActiveResultSets=true";

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            IEnumerable<ProductCategory> categories = null;
            using (var conn = new SqlConnection(connstr))
            {
                categories = conn.Query<ProductCategory>("SELECT * FROM Production.ProductCategory");
            }
            return categories;
        }

        public IEnumerable<ProductSubcategory> GetProductSubcategoriesByCategoryId(int id)
        {
            IEnumerable<ProductSubcategory> categories = null;
            using (var conn = new SqlConnection(connstr))
            {
                categories = conn.Query<ProductSubcategory>("SELECT * FROM Production.ProductSubcategory WHERE ProductCategoryID = @id", new { id = id });
            }
            return categories;
        }

        public IEnumerable<UnionCategoryModel> GetCategoryTreeModels()
        {
            IEnumerable<UnionCategoryModel> categories = null;
            using (var conn = new SqlConnection(connstr))
            {
                categories = conn.Query<UnionCategoryModel>(@"SELECT ProductCategoryID,0 AS ProductSubcategoryID,Name FROM Production.ProductCategory UNION ALL SELECT ProductCategoryID, ProductSubcategoryID, Name FROM Production.ProductSubcategory");
            }
            return categories;
        }

        public IEnumerable<Product> GetProductsBySubCategoryId(int id)
        {
            IEnumerable<Product> categories = null;
            using (var conn = new SqlConnection(connstr))
            {
                categories = conn.Query<Product>("SELECT * FROM Production.Product WHERE ProductSubcategoryID = @id", new { id = id });
            }
            return categories;
        }

        public IEnumerable<ProductWithPhotoModel> GetProductsBySubCategoryIdWithPhoto(int id)
        {
            IEnumerable<ProductWithPhotoModel> categories = null;
            using (var conn = new SqlConnection(connstr))
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
            using (var conn = new SqlConnection(connstr))
            {
                product = conn.QueryFirstOrDefault<Product>("SELECT * FROM Production.Product WHERE ProductID = @id", new { id = id });
            }
            return product;
        }
    }
}
