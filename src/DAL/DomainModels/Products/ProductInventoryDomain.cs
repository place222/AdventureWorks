using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels.Products
{
    public class ProductInventoryDomain
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 库存地址编号
        /// </summary>
        public int LocationID { get; set; }
        /// <summary>
        /// 库存中的仓库号
        /// </summary>
        public string Shelf { get; set; }
        /// <summary>
        /// 库存货架上的容器编号
        /// </summary>
        public int Bin { get; set; }
        /// <summary>
        /// 存货数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 制造单位成本
        /// </summary>
        public decimal CostRate { get; set; }
        /// <summary>
        /// 制造单位能力
        /// </summary>
        public decimal Availability { get; set; }
    }
}
