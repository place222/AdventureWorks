using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.DomainModels.Categories;
using Microsoft.Extensions.Options;
using DAL.Models;

namespace DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public ConnectionOptions Options { get; }

        public CategoryRepository(IOptions<ConnectionOptions> options )
        {
            Options = options.Value;
        }
        public async Task<IEnumerable<CategoryDomain>> GetCategoriesAsync()
        {
            var sql = @"SELECT ProductCategoryID,NULL AS ProductSubcategoryID,Name FROM Production.ProductCategory
                        UNION ALL
                        SELECT ProductCategoryID ,ProductSubcategoryID,Name FROM Production.ProductSubcategory
                        ORDER BY ProductCategoryID,ProductSubcategoryID";
            using (var conn = new SqlConnection(Options.AdventureWorkConnection))
            {
                return await conn.QueryAsync<CategoryDomain>(sql);
            }
        }
    }
}
