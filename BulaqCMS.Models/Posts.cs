using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 文章模型
    /// </summary>
    public class PostsModel
    {
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 作者 ID
        /// </summary>
        public int AuthorID { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 发表时间
        /// </summary>
        public Nullable<DateTime> SendTime { get; set; }

        /// <summary>
        /// 发表用户 信息
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// 发表 IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 显示状态
        /// 1: open 默认
        /// 2: onlyme 只有我自己看
        /// 3: users  登陆用户看
        /// 4: hide 隐藏
        /// </summary>
        public short VisibleState { get; set; }

        /// <summary>
        /// 是否发表评论
        /// </summary>
        public bool CanComment { get; set; }

        /// <summary>
        /// 浏览文章是否需要密码
        /// </summary>
        public bool NeadPassword { get; set; }

        /// <summary>
        /// 文章浏览密码, 如果文章不需要密码,不生效
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 文章类型
        /// false: 普通文章
        /// true:  页面
        /// </summary>
        public bool PostType { get; set; }

        /// <summary>
        /// 是否修改了
        /// </summary>
        public bool Modified { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public Nullable<DateTime> LastModifiedTime { get; set; }

        /// <summary>
        /// 文章图片
        /// </summary>
        public string PostImage { get; set; }

        /// <summary>
        /// 文章主题
        /// 如果为空,则别是没有主题
        /// </summary>
        public string ThemeGuid { get; set; }

        /// <summary>
        /// 删除表示,是否垃圾文章
        /// </summary>
        public bool DelFlag { get; set; }

        /// <summary>
        /// 是否批准
        /// </summary>
        public bool Approved { get; set; }

        /// <summary>
        /// 是否草稿
        /// </summary>
        public bool Practice { get; set; }


        #region 额外参数

        /// <summary>
        /// 这个文章所对应的所有专辑
        /// </summary>
        public ICollection<CategoriesModel> Categories { get; set; }

        /// <summary>
        /// 该文章所对应的所有标签
        /// </summary>
        public ICollection<TagsModel> Tags { get; set; }

        /// <summary>
        /// 该文章的所有评论
        /// </summary>
        public ICollection<CommentsModel> Comments { get; set; }

        /// <summary>
        /// 该文章的评论个数
        /// </summary>
        public int CommentsCount { get; set; }

        /// <summary>
        /// 文章作者
        /// </summary>
        public UsersModel Author { get; set; }

        #endregion


    }
}
