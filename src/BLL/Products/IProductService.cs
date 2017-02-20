using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Products.Dtos;
using BLL.Products.Dtos.Cateogries;
using BLL.Products.Dtos.Products;

namespace BLL.Products
{
    public interface IProductService
    {
        Task<BasePageDto<ProductModelDto>> GetProductModelsByPageAsync(BasePageInput input);
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        Task<BasePageDto<ProductDto>> GetProductsByPageAsync(BasePageInput input);
        Task<ProductDetailDto> GetProdutDetailByIdAsync(int productId);
    }
}
