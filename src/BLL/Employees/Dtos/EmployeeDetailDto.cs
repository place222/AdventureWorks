using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Employees.Dtos
{
    public class EmployeeDetailDto
    {
        /// <summary>
        /// 基本信息
        /// </summary>
        public EmployeeInfoDto EmployeeInfo { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public IEnumerable<EmailAddressesDto> EmployeeEmailAddresses { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public IEnumerable<EmployeeAddressDto> EmployeeAddresses { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public IEnumerable<EmployeeContactDto> EmployeeContacts { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public IEnumerable<EmployeePhoneDto> EmployeePhones { get; set; }
    }
}
