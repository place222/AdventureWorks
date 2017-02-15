using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.HumanResources
{
    /// <summary>
    /// 求职者提交给人力资源部的简历。
    /// </summary>
    public class JobCandidate
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int JobCandidateID { get; set; }
        /// <summary>
        /// 雇佣后的关联
        /// </summary>
        public int? BusinessEntityID { get; set; }
        /// <summary>
        /// 简历xml
        /// </summary>
        public string Resume { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
