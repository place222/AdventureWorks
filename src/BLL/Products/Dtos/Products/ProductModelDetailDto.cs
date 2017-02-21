using System.Collections.Generic;

namespace BLL.Products.Dtos.Products
{
    public class ProductModelDetailDto
    {
        /// <summary>
        /// 基本数据
        /// </summary>
        public ProductModelDto ProductModel { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public ProductDescriptionDto ProductDescription { get; set; }
        /// <summary>
        /// 装配图
        /// </summary>
        public IEnumerable<IllustrationDto> Illustrations { get; set; }
    }
}
