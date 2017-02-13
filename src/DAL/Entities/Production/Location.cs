using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 制造地址
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 制造地点
        /// </summary>
        public int LocationID { get; set; }
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
        /// <summary>
        /// 上次更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
