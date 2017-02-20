using System;

namespace BLL.Products.Dtos.Products
{
    public class ProductDetailCostHistoryDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 产品成本开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 成本价格
        /// </summary>
        public decimal StandardCost { get; set; }
    }
}
