using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Person
{
    /// <summary>
    /// 人员电话关系
    /// </summary>
    public class PersonPhone
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int PhoneNumberTypeID { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
