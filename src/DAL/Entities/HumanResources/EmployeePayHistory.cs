using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.HumanResources
{
    /// <summary>
    /// 员工薪水调整记录
    /// </summary>
    public class EmployeePayHistory
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 调薪日期
        /// </summary>
        public DateTime RateChangeDate { get; set; }
        /// <summary>
        /// 调薪金额
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// 支付 1 月付 2 半月发
        /// </summary>
        public int PayFrequency { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
