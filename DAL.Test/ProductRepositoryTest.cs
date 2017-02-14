using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Xunit;

namespace DAL.Test
{
    public class ProductRepositoryTest
    {
        public ProductRepositoryTest()
        {

        }

        [Fact]
        public void ProductCategoryTest()
        {
            IProductRepository productRepository = new ProductRepository();

            var cate = productRepository.GetProductCategories();


            Assert.NotEmpty(cate);

        }

        [Fact]
        public void ProductSubCategoryTest()
        {
            IProductRepository productRepository = new ProductRepository();

            var cate = productRepository.GetProductSubcategoriesByCategoryId(1);

            Assert.NotEmpty(cate);
            Assert.Equal(3, cate.Count());
        }

        [Fact]
        public void GetProductsBySubCategoryIdTest()
        {
            IProductRepository productRepository = new ProductRepository();

            var cate = productRepository.GetProductsBySubCategoryId(1);

            Assert.NotEmpty(cate);
        }
    }
}
