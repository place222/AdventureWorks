using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Person
{
    /// <summary>
    /// 人员
    /// </summary>
    public class Person
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int BusinessEntityID { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string PersonType { get; set; }
        /// <summary>
        /// 名字格式
        /// </summary>
        public bool NameStyle { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EmailPromotion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AdditionalContactInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Demographics { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
