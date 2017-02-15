using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Purchasing
{
    /// <summary>
    /// 产品和供应商关系表
    /// </summary>
    public class ProductVendor
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 平均下单到货的天数
        /// </summary>
        public int AverageLeadTime { get; set; }
        /// <summary>
        /// 供应商的标准价
        /// </summary>
        public decimal StandardPrice { get; set; }
        /// <summary>
        /// 上次的花费
        /// </summary>
        public decimal? LastReceiptCost { get; set; }
        /// <summary>
        /// 上次交易时间
        /// </summary>
        public DateTime? LastReceiptDate { get; set; }
        /// <summary>
        /// 最小下单
        /// </summary>
        public int MinOrderQty { get; set; }
        /// <summary>
        /// 最大
        /// </summary>
        public int MaxOrderQty { get; set; }
        /// <summary>
        /// 现在有多少量的订单
        /// </summary>
        public int? OnOrderQty { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitMeasureCode { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
