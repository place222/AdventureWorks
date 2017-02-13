using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品和产品图片关系
    /// </summary>
    public class ProductProductPhoto
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 图片编号
        /// </summary>
        public int ProductPhotoID { get; set; }
        /// <summary>
        /// 是不是主图片
        /// </summary>
        public bool Primary { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
