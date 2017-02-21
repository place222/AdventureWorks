using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Products.Dtos.Products
{
    public class ProductDescriptionDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ProductDescriptionID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
