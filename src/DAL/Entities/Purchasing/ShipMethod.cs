using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Purchasing
{
    /// <summary>
    /// 货运方式
    /// </summary>
    public class ShipMethod
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ShipMethodID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 起运价格
        /// </summary>
        public decimal ShipBase { get; set; }
        /// <summary>
        /// 每磅价格
        /// </summary>
        public decimal ShipRate { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
