using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Production;

namespace MyFirstCoreWeb.Models.ProductViewModels
{
    public class ProductWithPhotoViewModel : Product
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductPhotoID { get; set; }
        /// <summary>
        /// 小图
        /// </summary>
        public string ThumbNailPhoto { get; set; }
        /// <summary>
        /// 小图名字
        /// </summary>
        public string ThumbnailPhotoFileName { get; set; }
        /// <summary>
        /// 大图
        /// </summary>
        public string LargePhoto { get; set; }
        /// <summary>
        /// 大图名字
        /// </summary>
        public string LargePhotoFileName { get; set; }
    }
}
