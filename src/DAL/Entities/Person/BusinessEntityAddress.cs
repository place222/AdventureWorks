using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Person
{
    /// <summary>
    /// 业务实体地址关系表
    /// </summary>
    public class BusinessEntityAddress
    {
        /// <summary>
        /// 实体编号
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 地址编号
        /// </summary>
        public int AddressID { get; set; }
        /// <summary>
        /// 地址类型
        /// </summary>
        public int AddressTypeID { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
