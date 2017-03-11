using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Products;
using BLL.Products.Dtos;
using BLL.Products.Dtos.Cateogries;
using BLL.Products.Dtos.Products;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFirstCoreWebApi.Controllers
{
    /// <summary>
    /// 产品方案
    /// </summary>
    [EnableCors("AllowDomain")]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(ILoggerFactory loggerFactory, IProductService productService) : base(loggerFactory)
        {
            _productService = productService;
        }

        #region 产品型号的接口
        /*
         * 产品型号接口
         * 1.分页拉去产品型号列表
         * 2.创建产品型号
         * 3.修改产品型号
         * 4.删除产品型号
         * 5.查看型号的描述
         * */
        [Route("GetProductModelsByPage")]
        [HttpPost]
        public async Task<BasePageDto<ProductModelDto>> GetProductModelsByPage([FromForm]BasePageInput input)
        {
            try
            {
                return await _productService.GetProductModelsByPageAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        [Route("GetProductModelDetailById")]
        [HttpPost]
        public async Task<ProductModelDetailDto> GetProductModelDetailById([FromQuery] int productModelId)
        {
            try
            {
                return await _productService.GetProductModelDetailByIdAsync(productModelId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        [Route("AddProductModel")]
        [HttpPost]
        public async Task AddProductModel([FromBody] AddProductModelInput input)
        {
            try
            {
                //await _productService.AddProductModelAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        [Route("UpdateProductModel")]
        [HttpPost]
        public async Task UpdateProductModel([FromBody] UpdateProductModelInput input)
        {
            try
            {
                //await _productService.UpdateProductModelAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        [Route("DeleteProductModel")]
        [HttpPost]
        public async Task DeleteProductModel([FromQuery] int productModelId)
        {
            try
            {
                //await _productService.DeleteProductModelAsync(productModelId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        #endregion

        #region 产品分类
        /*
         * 1.添加分类 
         * 2.查看分类 //TODO
         * 3.修改分类
         * 4.删除分类
         * */
        /// <summary>
        /// 获取嵌套结构的分类列表
        /// </summary>
        /// <returns></returns>
        [Route("GetCategories")]
        [HttpPost]
        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            try
            {
                return await _productService.GetCategoriesAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Route("AddProductCategory")]
        [HttpPost]
        public async Task AddProductCategory([FromBody] AddProductCategoryInput input)
        {
            try
            {
                //await _productService.AddProductCategoryAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Route("UpdateProductCategory")]
        [HttpPost]
        public async Task UpdateProductCategory([FromBody] UpdateProductCategoryInput input)
        {
            try
            {
                //await _productService.UpdateProductCategoryAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        [Route("DeleteProductCategory")]
        [HttpPost]
        public async Task DeleteProductCategory([FromQuery] int productCategoryId)
        {
            try
            {
                //await _productService.DeleteProductCategoryAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        #endregion

        #region 产品
        /*
         * 1.产品列表
         * 2.产品详情
         * **/

        [HttpPost]
        [Route("GetProductsByPage")]
        public async Task<BasePageDto<ProductDto>> GetProductsByPage([FromForm] BasePageInput input)
        {
            try
            {
                return await _productService.GetProductsByPageAsync(input);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }

        [HttpPost]
        [Route("GetProdutDetailById")]
        public async Task<ProductDetailDto> GetProdutDetailById([FromQuery]int productId)
        {
            try
            {
                return await _productService.GetProdutDetailByIdAsync(productId);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.GetBaseException().Message);
                throw;
            }
        }
        #endregion
    }
}
