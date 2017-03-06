using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Basic.Dtos
{
    /// <summary>
    /// 联系方式
    /// </summary>
    public class ContactTypeDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ContactTypeID { get; set; }
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
