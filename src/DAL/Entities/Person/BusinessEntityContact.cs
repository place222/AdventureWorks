using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Person
{
    /// <summary>
    /// 业务实体联系人关系表
    /// </summary>
    public class BusinessEntityContact
    {
        /// <summary>
        /// 业务实体
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public int PersonID { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public int ContactTypeID { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
