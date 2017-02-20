using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Products.Dtos;
using BLL.Products.Dtos.Cateogries;
using DAL.Repositories;

namespace BLL.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductModelRepository _productModelRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductModelRepository productModelRepository, ICategoryRepository categoryRepository)
        {
            _productModelRepository = productModelRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<BasePageDto<ProductModelDto>> GetProductModelsByPageAsync(BasePageInput input)
        {
            var result = await _productModelRepository.GetProductModelsByPageAsync(input.Start, input.Length);

            return Mapper.Map<BasePageDto<ProductModelDto>>(result);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var result = await _categoryRepository.GetCategoriesAsync();
            var models = new List<CategoryDto>();
            models.AddRange(result.Where(x => x.ProductSubCategoryID == null).Select(x => new CategoryDto()
            {
                Name = x.Name,
                ProductCategoryID = x.ProductCategoryID,
                ProductSubCategoryID = x.ProductSubCategoryID,
                Children =
                    result.Where(c => c.ProductSubCategoryID != null && c.ProductCategoryID == x.ProductCategoryID)
                        .Select(c => new CategoryDto
                        {
                            Name = x.Name,
                            ProductCategoryID = x.ProductCategoryID,
                            ProductSubCategoryID = x.ProductSubCategoryID
                        })
            }));
            return models;
        }
    }
}
