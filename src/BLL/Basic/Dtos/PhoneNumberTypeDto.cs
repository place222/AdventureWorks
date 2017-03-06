using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Basic.Dtos
{
    public class PhoneNumberTypeDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int PhoneNumberTypeID { get; set; }
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
