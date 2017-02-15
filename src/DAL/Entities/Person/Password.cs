using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Person
{
    /// <summary>
    /// 密码
    /// </summary>
    public class Password
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// 盐
        /// </summary>
        public string PasswordSalt { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
