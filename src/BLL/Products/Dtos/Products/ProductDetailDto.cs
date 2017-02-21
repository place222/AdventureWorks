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
        /// <summary>
        /// 销售价格记录表
        /// </summary>
        public IEnumerable<ProductDetailListPriceHistoryDto> ProductListPriceHistories { get; set; }
        /// <summary>
        /// 产品库存信息
        /// </summary>
        public IEnumerable<ProductInventoryDto> ProductInventories { get; set; }
    }
}
