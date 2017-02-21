using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Products.Dtos;
using BLL.Products.Dtos.Cateogries;
using BLL.Products.Dtos.Products;
using DAL.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace BLL.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductModelRepository _productModelRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductModelRepository productModelRepository, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _productModelRepository = productModelRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
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

        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BasePageDto<ProductDto>> GetProductsByPageAsync(BasePageInput input)
        {
            var result = await _productRepository.GetProductsByPageAsync(input.Start, input.Length);

            return Mapper.Map<BasePageDto<ProductDto>>(result);
        }
        /// <summary>
        /// 查看产品详情
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ProductDetailDto> GetProdutDetailByIdAsync(int productId)
        {
            var result = await _productRepository.GetProdutDetailByIdAsync(productId);

            return Mapper.Map<ProductDetailDto>(result);
        }

        public async Task<ProductModelDetailDto> GetProductModelDetailByIdAsync(int productModelId)
        {
            var result = await _productModelRepository.GetProductModelDetailByIdAsync(productModelId);

            return Mapper.Map<ProductModelDetailDto>(result);
        }
    }
}
