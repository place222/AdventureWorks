using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 自行车装配图
    /// </summary>
    public class Illustration
    {
        /// <summary>
        /// 装配编号
        /// </summary>
        public int IllustrationID { get; set; }
        /// <summary>
        /// 装配图xml
        /// </summary>
        public string Diagram { get; set; }
        /// <summary>
        /// 上次更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
