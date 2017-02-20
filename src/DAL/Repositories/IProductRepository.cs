using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels;
using DAL.DomainModels.Products;
using DAL.Entities.Production;

namespace DAL.Repositories
{
    /// <summary>
    /// 产品的展示方面的接口
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<ProductCategory> GetProductCategories();
        IEnumerable<ProductSubcategory> GetProductSubcategoriesByCategoryId(int id);
        IEnumerable<UnionCategoryModel> GetCategoryTreeModels();
        IEnumerable<Product> GetProductsBySubCategoryId(int id);
        IEnumerable<ProductWithPhotoModel> GetProductsBySubCategoryIdWithPhoto(int id);
        Product GetProductById(int id);
        Task<PageDomain<ProductDomain>> GetProductsByPageAsync(int start, int length);
        Task<ProductDetailDomain> GetProdutDetailByIdAsync(int productId);
    }
}
