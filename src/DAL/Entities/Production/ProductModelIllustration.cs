using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品模型和装配图关系
    /// </summary>
    public class ProductModelIllustration
    {
        /// <summary>
        /// 产品模型编号
        /// </summary>
        public int ProductModelID { get; set; }
        /// <summary>
        /// 装配图编号
        /// </summary>
        public int IllustrationID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
