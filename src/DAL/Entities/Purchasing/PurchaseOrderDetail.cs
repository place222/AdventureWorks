using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Purchasing
{
    /// <summary>
    /// 供应商订单详情
    /// </summary>
    public class PurchaseOrderDetail
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int PurchaseOrderID { get; set; }
        /// <summary>
        /// 详情号
        /// </summary>
        public int PurchaseOrderDetailID { get; set; }
        /// <summary>
        /// 收货时间
        /// </summary>
        public DateTime DueDate { get; set; }
        /// <summary>
        /// 订购数量
        /// </summary>
        public int OrderQty { get; set; }
        /// <summary>
        /// 产品
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 单位价格
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal LineTotal { get; set; }
        /// <summary>
        /// 实际收货数量
        /// </summary>
        public decimal ReceivedQty { get; set; }
        /// <summary>
        /// 检验拒收数量
        /// </summary>
        public decimal RejectedQty { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public decimal StockedQty { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
