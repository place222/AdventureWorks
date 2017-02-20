using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Products.Dtos.Products
{
    public class ProductDetailPhotoDto
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductPhotoID { get; set; }
        /// <summary>
        /// 大图
        /// </summary>
        public byte[] LargePhoto { get; set; }
    }
}
