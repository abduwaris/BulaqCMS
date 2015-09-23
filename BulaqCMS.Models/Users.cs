using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class UsersModel
    {
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NiceName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 网站
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegisterTime { get; set; }

        #region 额外参数

        /// <summary>
        /// 这个用户的所有文章
        /// </summary>
        public ICollection<PostsModel> Posts { get; set; }

        /// <summary>
        /// 这个用户的文章个数
        /// </summary>
        public int PostsCount { get; set; }

        /// <summary>
        /// 该用户写的所有评论
        /// </summary>
        public ICollection<CommentsModel> Comments { get; set; }

        /// <summary>
        /// 这个用户写的评论数
        /// </summary>
        public int CommentsCount { get; set; }


        /// <summary>
        /// 这个用户所有参数集合
        /// </summary>
        public ICollection<UserOptionsModel> Options { get; set; }


        #endregion
    }
}
