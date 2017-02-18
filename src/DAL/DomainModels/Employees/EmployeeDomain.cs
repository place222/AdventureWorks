using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels.Employees
{
    /// <summary>
    /// 员工列表的数据
    /// </summary>
    public class EmployeeDomain
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 雇佣日期
        /// </summary>
        public DateTime HireDate { get; set; }
        /// <summary>
        /// 当前状态 Inactive,  Active
        /// </summary>
        public bool CurrentFlag { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
    }
}
