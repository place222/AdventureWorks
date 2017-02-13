using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities.Production
{
    /// <summary>
    /// 产品评论
    /// </summary>
    public class ProductReview
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ProductReviewID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductID { get; set; }
        /// <summary>
        /// 评论标题
        /// </summary>
        public string ReviewerName { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime ReviewDate { get; set; }
        /// <summary>
        /// 评论人邮件地址
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// 留言
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
