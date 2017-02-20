using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Products.Dtos;
using BLL.Products.Dtos.Cateogries;

namespace BLL.Products
{
    public interface IProductService
    {
        Task<BasePageDto<ProductModelDto>> GetProductModelsByPageAsync(BasePageInput input);
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}
