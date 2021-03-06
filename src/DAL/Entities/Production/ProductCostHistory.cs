﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品成本历史纪录表
    /// </summary>
    public class ProductCostHistory
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 产品成本开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 成本价格
        /// </summary>
        public decimal StandardCost { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
