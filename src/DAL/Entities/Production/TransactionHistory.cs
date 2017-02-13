using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 记录每个采购订单，销售订单，或工作订单交易日期。
    /// </summary>
    public class TransactionHistory
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int TransactionID { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public int ReferenceOrderID { get; set; }
        /// <summary>
        /// 订单线的编号
        /// </summary>
        public int ReferenceOrderLineID { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public string TransactionType { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal ActualCost { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
