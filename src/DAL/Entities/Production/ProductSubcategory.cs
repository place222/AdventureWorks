using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品二级目录
    /// </summary>
    public class ProductSubcategory
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ProductSubcategoryID { get; set; }
        /// <summary>
        /// 一级编号
        /// </summary>
        public int ProductCategoryID { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
