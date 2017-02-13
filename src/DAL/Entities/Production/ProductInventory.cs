using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品库存信息
    /// </summary>
    public class ProductInventory
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
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
