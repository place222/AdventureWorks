using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 包含所有语言的产品描述
    /// </summary>
    public class ProductDescription
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ProductDescriptionID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
