using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 工作订单详细
    /// </summary>
    public class WorkOrderRouting
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int WorkOrderID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 生产过程序列
        /// </summary>
        public int OperationSequence { get; set; }
        /// <summary>
        /// 生产地
        /// </summary>
        public int LocationID { get; set; }
        /// <summary>
        /// 计划生产开始时间
        /// </summary>
        public DateTime ScheduledStartDate { get; set; }
        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime ScheduledEndDate { get; set; }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? ActualStartDate { get; set; }
        /// <summary>
        /// 实际结束时间
        /// </summary>
        public DateTime? ActualEndDate { get; set; }
        /// <summary>
        /// 总共用时
        /// </summary>
        public decimal? ActualResourceHrs { get; set; }
        /// <summary>
        /// 计划费用
        /// </summary>
        public decimal PlannedCost { get; set; }
        /// <summary>
        /// 实际费用
        /// </summary>
        public decimal? ActualCost { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
