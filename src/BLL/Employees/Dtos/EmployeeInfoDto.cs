using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Employees.Dtos
{
    public class EmployeeInfoDto
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string PersonType { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EmailPromotion { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string NationalDNumber { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginID { get; set; }
        /// <summary>
        /// 工作头衔
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// 婚姻状态
        /// </summary>
        public string MaritalStatus { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 雇佣日期
        /// </summary>
        public DateTime HireDate { get; set; }
        /// <summary>
        /// 薪水方式 工作分类。0 =小时，不免除集体谈判。1 =薪水，
        //  集体谈判豁免。
        /// </summary>
        public bool SalariedFlag { get; set; }
        /// <summary>
        /// 可用年假
        /// </summary>
        public int VacationHours { get; set; }
        /// <summary>
        /// 可用病假
        /// </summary>
        public int SikLeaveHours { get; set; }
        /// <summary>
        /// 当前状态 Inactive,  Active
        /// </summary>
        public bool CurrentFlag { get; set; }
    }
}
