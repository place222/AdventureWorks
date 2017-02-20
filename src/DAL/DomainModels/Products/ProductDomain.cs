using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.DomainModels.Products
{
    public class ProductDomain
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 商品标识码
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// false:产品是采购的 true:商品内部制造的
        /// </summary>
        public bool MakeFlag { get; set; }
        /// <summary>
        /// false:不畅销 true:畅销
        /// </summary>
        public bool FinishedGoodsFlag { get; set; }
        /// <summary>
        /// 小图
        /// </summary>
        public byte[] ThumbNailPhoto { get; set; }
    }
}
