using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.TemplateModels
{
    public class Comment
    {
        #region 属性
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
        /// 评论纯文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime Time { get; set; }

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

        #endregion

        #region 扩展属性

        Post _Post;

        /// <summary>
        /// 这个评论所属的文章
        /// </summary>
        public Post Post
        {
            get
            {
                if (_Post == null)
                {
                    //从数据库中获取文章
                }
                return _Post;
            }
            internal set
            {
                _Post = value;
            }
        }

        ICollection<CommentOption> _Options;

        /// <summary>
        /// 这个评论的所有参数
        /// </summary>
        public ICollection<CommentOption> Options
        {
            get
            {
                if (_Options == null)
                {

                }
                return _Options;
            }
        }

        User _Author;

        /// <summary>
        /// 作者, 不一定有
        /// </summary>
        public User Author
        {
            get
            {
                if (_Author == null)
                {
                    if (this.AuthorID > 0)
                    {
                        //从数据库中获取
                    }
                }
                return _Author;
            }
        }

        Comment _Parent;

        /// <summary>
        /// 父评论
        /// </summary>
        public Comment Parent
        {
            get
            {
                if (_Parent == null)
                {
                    if (this.ParentID > 0)
                    {

                    }
                }
                return _Parent;
            }
            internal set
            {
                _Parent = value;
            }
        }

        ICollection<Comment> _Comments;

        /// <summary>
        /// 子评论
        /// </summary>
        public ICollection<Comment> Comments
        {
            get
            {
                if (_Comments == null)
                {
                    //从数据库中读取

                    //遍历
                    if (_Comments.Count > 0)
                        foreach (var com in _Comments)
                            com.Parent = this;
                }
                return _Comments;
            }
        }

        /// <summary>
        /// 判断是否有父评论
        /// </summary>
        public bool HasParent
        {
            get
            {
                return this.Parent != null;
            }
        }

        /// <summary>
        /// 判断是否有子评论
        /// </summary>
        public bool HasChilds
        {
            get
            {
                return Comments != null && Comments.Count > 0;
            }
        }

        /// <summary>
        /// 判断是否有本地作者
        /// </summary>
        public bool HasAuthor
        {
            get
            {
                return this.Author != null;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 分页获取评论
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ICollection<Comment> Pages(int pageIndex, int pageSize)
        {

            return null;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetOption(string key, object value)
        {

        }

        /// <summary>
        /// 获取评论参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetOption(string key)
        {
            return string.Empty;
        }

        /// <summary>
        /// 获取文章纯文本从头制定长度的内容
        /// </summary>
        /// <param name="length">获取内容长度</param>
        /// <returns></returns>
        public string GetText(int length)
        {
            if (string.IsNullOrEmpty(this.Text)) return string.Empty;
            if (length >= this.Text.Length) return this.Text;
            return this.Text.Substring(0, length);
        }

        #endregion
    }
}
