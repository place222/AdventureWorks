using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 测量单位表
    /// </summary>
    public class UnitMeasure
    {
        /// <summary>
        /// 测量编号
        /// </summary>
        public string UnitMeasureCode { get; set; }
        /// <summary>
        /// 测量描述
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
