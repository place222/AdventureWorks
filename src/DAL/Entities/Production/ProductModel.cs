using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品型号分类
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ProductModelID { get; set; }
        /// <summary>
        /// 模型表述
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// xml格式的详细产品目录信息
        /// </summary>
        public string CatalogDescription { get; set; }
        /// <summary>
        /// xml格式的制造指令
        /// </summary>
        public string Instructions { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
