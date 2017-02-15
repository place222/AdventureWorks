using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.HumanResources
{
    /// <summary>
    /// 员工调动记录
    /// </summary>
    public class EmployeeDepartmentHistory
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public int DepartmentID { get; set; }
        /// <summary>
        /// 班值编号
        /// </summary>
        public int ShiftID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
