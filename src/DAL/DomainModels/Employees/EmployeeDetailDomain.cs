using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities.Person;

namespace DAL.DomainModels.Employees
{
    /// <summary>
    /// 员工详情
    /// </summary>
    public class EmployeeDetailDomain
    {
        /// <summary>
        /// 基本信息
        /// </summary>
        public EmployeeInfoDomain EmployeeInfo { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public IEnumerable<EmailAddresses> EmployeeEmailAddresses { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public IEnumerable<EmployeeAddressDomain> EmployeeAddresses { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public IEnumerable<EmployeeContactDomain> EmployeeContacts { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public IEnumerable<EmployeePhoneDomain> EmployeePhones { get; set; }
    }
}
