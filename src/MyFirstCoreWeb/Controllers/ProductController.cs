using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using MyFirstCoreWeb.Models.ProductViewModels;

namespace MyFirstCoreWeb.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            //var viewModel = new IndexViewModel();

            //var cates = _productRepository.GetCategoryTreeModels();

            //var products = _productRepository.GetProductsBySubCategoryIdWithPhoto(id);

            //foreach (var productWithPhotoModel in products)
            //{
            //    var model = new ProductWithPhotoViewModel();
            //    model.LargePhotoFileName = productWithPhotoModel.LargePhotoFileName;
            //    model.ThumbnailPhotoFileName = productWithPhotoModel.ThumbnailPhotoFileName;
            //    model.ProductPhotoID = productWithPhotoModel.ProductPhotoID;
            //    model.LargePhoto = Convert.ToBase64String(productWithPhotoModel.LargePhoto);
            //    model.ThumbNailPhoto = Convert.ToBase64String(productWithPhotoModel.ThumbNailPhoto);
            //    model.ProductID = productWithPhotoModel.ProductID;
            //    model.Name = productWithPhotoModel.Name;

            //    viewModel.ProductWithPhotoModels.AsList().Add(model);
            //}
            //foreach (var productCategory in cates.Where(x => x.ProductSubCategoryID == 0))
            //{
            //    var catevms = new CategoryTreeViewModel();
            //    catevms.ProductSubCategoryID = productCategory.ProductSubCategoryID;
            //    catevms.ProductCategoryID = productCategory.ProductCategoryID;
            //    catevms.Name = productCategory.Name;
            //    catevms.Children = new List<CategoryTreeViewModel>();
            //    foreach (var source in cates.Where(x => x.ProductCategoryID == productCategory.ProductCategoryID && x.ProductSubCategoryID != 0))
            //    {
            //        var scatevms = new CategoryTreeViewModel();
            //        scatevms.ProductSubCategoryID = source.ProductSubCategoryID;
            //        scatevms.ProductCategoryID = source.ProductCategoryID;
            //        scatevms.Name = source.Name;
            //        catevms.Children.AsList().Add(scatevms);
            //    }
            //    viewModel.CategoryTreeViewModels.AsList().Add(catevms);
            //}
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
    }
}