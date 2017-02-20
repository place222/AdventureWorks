using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MyFirstCoreWeb.Models.ProductViewModels;
using BLL.Products;

namespace MyFirstCoreWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 产品型号视图
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductModel()
        {
            return View();
        }
        /// <summary>
        /// 产品分类
        /// </summary>
        /// <returns></returns>
        public IActionResult Category()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detail(int id)
        {
            var model = await _productService.GetProdutDetailByIdAsync(id);
            
            return View(model);
        }
    }
}