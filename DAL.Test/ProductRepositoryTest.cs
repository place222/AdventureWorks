using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.Extensions.Options;
using MyFirstCoreWeb.Models;
using Xunit;

namespace DAL.Test
{
    public class ProductRepositoryTest
    {
        public ProductRepositoryTest()
        {

        }
        private readonly IProductRepository _productRepository = new ProductRepository(new OptionsWrapper<ConnectionOptions>(new ConnectionOptions()));

        [Fact]
        public void ProductCategoryTest()
        {

            var cate = _productRepository.GetProductCategories();


            Assert.NotEmpty(cate);

        }

        [Fact]
        public void ProductSubCategoryTest()
        {

            var cate = _productRepository.GetProductSubcategoriesByCategoryId(1);

            Assert.NotEmpty(cate);
            Assert.Equal(3, cate.Count());
        }

        [Fact]
        public void GetProductsBySubCategoryIdTest()
        {

            var cate = _productRepository.GetProductsBySubCategoryId(1);

            Assert.NotEmpty(cate);
        }
    }
}
