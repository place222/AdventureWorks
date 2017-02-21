using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Production;

namespace DAL.DomainModels.ProductModels
{
    /// <summary>
    /// 产品型号详情
    /// </summary>
    public class ProductModelDetailDoamin
    {
        /// <summary>
        /// 基本数据
        /// </summary>
        public ProductModel ProductModel { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public ProductDescription ProductDescription { get; set; }
        /// <summary>
        /// 装配图
        /// </summary>
        public IEnumerable<Illustration> Illustrations { get; set; }
    }
}
