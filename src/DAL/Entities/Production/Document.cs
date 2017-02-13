using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品维护文件
    /// </summary>
    public class Document
    {
        /// <summary>
        /// 文件编号 hierarchyid
        /// </summary>
        public string DocumentNode { get; set; }
        /// <summary>
        /// 文档目录级别
        /// </summary>
        public int? DocumentLevel { get; set; }
        /// <summary>
        /// 文件名字
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 文件为湖人 Employee.BusinessEntityID
        /// </summary>
        public int Owner { get; set; }
        /// <summary>
        /// 是不是目录 false:是目录 true:是文件
        /// </summary>
        public bool FolderFlag { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 文件后缀名字
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// 文档修订号
        /// </summary>
        public string Revision { get; set; }
        /// <summary>
        /// 工程变更批准号
        /// </summary>
        public int ChangeNumber { get; set; }
        /// <summary>
        /// 1 =待定批准，2 =批准，3 =过时
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 文件摘要
        /// </summary>
        public string DocumentSummary { get; set; }
        /// <summary>
        /// 文件内容
        /// </summary>
        public byte[] DocumentBytes { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
