using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Purchasing
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Vendor
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///  1= Superior, 2 = Excellent, 3 = Above average, 4 = Average, 5 = Below average
        /// </summary>
        public int CreditRating { get; set; }
        /// <summary>
        /// 0 = Do not use if another vendor is available. 1 = Preferred over other vendors supplying
        //  the same product
        /// </summary>
        public bool PreferredVendorStatus { get; set; }
        /// <summary>
        /// 0 = Vendor no longer used. 1 = Vendor is actively used
        /// </summary>
        public bool ActiveFlag { get; set; }
        /// <summary>
        /// 服务地址
        /// </summary>
        public string PurchasingWebServiceURL { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
