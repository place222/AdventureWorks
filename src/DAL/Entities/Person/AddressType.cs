﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Person
{
    /// <summary>
    /// 地址类型
    /// </summary>
    public class AddressType
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int AddressTypeID { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
