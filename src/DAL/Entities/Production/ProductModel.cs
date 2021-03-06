﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#if NET461
using System.Data.SqlTypes;
#endif
namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品型号分类
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ProductModelID { get; set; }
        /// <summary>
        /// 模型表述
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// xml格式的详细产品目录信息
        /// </summary>
#if NET461 //TODO::看sqlxml
        public string CatalogDescription { get; set; }
#else
        public string CatalogDescription { get; set; }
#endif
        /// <summary>
        /// xml格式的制造指令
        /// </summary>
#if NET461
        public string Instructions { get; set; }
#else
        public string Instructions { get; set; }
#endif
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public ProductModel()
        {

        }
    }
}
