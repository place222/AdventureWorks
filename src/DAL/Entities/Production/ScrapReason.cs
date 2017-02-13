using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 制造失败原因纪录
    /// </summary>
    public class ScrapReason
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ScrapReasonID { get; set; }
        /// <summary>
        /// 失败描述
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
