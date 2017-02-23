using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BLL.Departments.Dtos
{
    public class DepartmentDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string DepartmentID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部门所在组
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
