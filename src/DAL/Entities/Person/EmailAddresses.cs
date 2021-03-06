﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Person
{
    /// <summary>
    /// 邮件地址
    /// </summary>
    public class EmailAddresses
    {
        /// <summary>
        /// 业务实体编号
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 邮件编号
        /// </summary>
        public int EmailAddressID { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
