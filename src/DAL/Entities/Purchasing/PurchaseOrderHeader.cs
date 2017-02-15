using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Purchasing
{
    /// <summary>
    /// 供应订单
    /// </summary>
    public class PurchaseOrderHeader
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int PurchaseOrderID { get; set; }
        /// <summary>
        /// 随着时间的推移跟踪订单的增量数量
        /// </summary>
        public int RevisionNumber { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建订单的Employee
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int VendorID { get; set; }
        /// <summary>
        /// 货运方式
        /// </summary>
        public int ShipMethodID { get; set; }
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 运输时间
        /// </summary>
        public DateTime ShipDate { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal SubTotal { get; set; }
        /// <summary>
        /// 税
        /// </summary>
        public decimal TaxAmt { get; set; }
        /// <summary>
        /// 货运价格
        /// </summary>
        public decimal Freight { get; set; }
        /// <summary>
        /// subTotal + taxAmt + freight
        /// </summary>
        public decimal TotalDue { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
