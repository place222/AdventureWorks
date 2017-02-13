using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 工作生产订单
    /// </summary>
    public class WorkOrder
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
        /// 生产数量
        /// </summary>
        public int OrderQty { get; set; }
        /// <summary>
        /// 生产入库数量
        /// </summary>
        public int StockedQty { get; set; }
        /// <summary>
        /// 失败数量
        /// </summary>
        public int ScrappedQty { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 经历日期
        /// </summary>
        public DateTime DueDate { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public int? ScrapReasonID { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
