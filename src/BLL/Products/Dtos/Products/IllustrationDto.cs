using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Products.Dtos.Products
{
    public class IllustrationDto
    {
        /// <summary>
        /// 装配编号
        /// </summary>
        public int IllustrationID { get; set; }
        /// <summary>
        /// 装配图xml
        /// </summary>
        public string Diagram { get; set; }
    }
}
