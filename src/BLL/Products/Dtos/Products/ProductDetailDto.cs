using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DomainModels.Products;

namespace BLL.Products.Dtos.Products
{
    public class ProductDetailDto
    {
        public ProductInfoDto ProductInfo { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public IEnumerable<ProductDetailPhotoDto> ProductPhotos { get; set; }
        /// <summary>
        /// 成本消耗
        /// </summary>
        public IEnumerable<ProductDetailCostHistoryDto> ProductCostHistories { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public IEnumerable<ProductReviewDto> ProductReviews { get; set; }

    }
}
