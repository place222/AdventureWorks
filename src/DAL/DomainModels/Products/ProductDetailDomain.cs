using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Production;

namespace DAL.DomainModels.Products
{
    public class ProductDetailDomain
    {
        public ProductInfoDomain ProductInfo { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public IEnumerable<ProductPhoto> ProductPhotos { get; set; }
        /// <summary>
        /// 成本消耗
        /// </summary>
        public IEnumerable<ProductCostHistory> ProductCostHistories { get; set; }
        /// <summary>
        /// 评论  
        /// </summary>
        public IEnumerable<ProductReview> ProductReviews { get; set; }
        /// <summary>
        /// 销售价格记录表
        /// </summary>
        public IEnumerable<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        /// <summary>
        /// 产品库存信息
        /// </summary>
        public IEnumerable<ProductInventoryDomain> ProductInventories { get; set; }
    }
}
