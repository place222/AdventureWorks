using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品图片
    /// </summary>
    public class ProductPhoto
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductPhotoID { get; set; }
        /// <summary>
        /// 小图
        /// </summary>
        public byte[] ThumbNailPhoto { get; set; }
        /// <summary>
        /// 小图名字
        /// </summary>
        public string ThumbnailPhotoFileName { get; set; }
        /// <summary>
        /// 大图
        /// </summary>
        public byte[] LargePhoto { get; set; }
        /// <summary>
        /// 大图名字
        /// </summary>
        public string LargePhotoFileName { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
