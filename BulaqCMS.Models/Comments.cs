using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 评论模型
    /// </summary>
    public class CommentsModel
    {

        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 对应文章 ID
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// 作者 ID, 不一定有
        /// </summary>
        public int AuthorID { get; set; }

        /// <summary>
        /// 父
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 评论正文
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime WriteTime { get; set; }

        /// <summary>
        /// 评论 Ip
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// UserAgent
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 作者名
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 网站
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 是否批准
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// 删除表示,垃圾评论
        /// </summary>
        public bool DelFlag { get; set; }



        #region 额外属性
        /// <summary>
        /// 这个评论所属的文章
        /// </summary>
        public PostsModel Posts { get; set; }

        /// <summary>
        /// 这个评论的所有参数
        /// </summary>
        public ICollection<CommentOptionsModel> Options { get; set; }

        #endregion
    }
}
