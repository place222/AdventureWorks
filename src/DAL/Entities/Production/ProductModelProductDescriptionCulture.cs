using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品模型的产品表述语言关系
    /// </summary>
    public class ProductModelProductDescriptionCulture
    {
        /// <summary>
        /// 产品模型编号
        /// </summary>
        public int ProductModelID { get; set; }
        /// <summary>
        /// 产品描述编号
        /// </summary>
        public int ProductDescriptionID { get; set; }
        /// <summary>
        /// 语言编号
        /// </summary>
        public string CultureID { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
