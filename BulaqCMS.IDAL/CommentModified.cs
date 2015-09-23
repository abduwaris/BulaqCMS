using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    /// <summary>
    /// 评论修改模式
    /// </summary>
    public enum CommentModified
    {
        /// <summary>
        /// 所有
        /// </summary>
        All,
        /// <summary>
        /// 内容修改
        /// </summary>
        Content,
        /// <summary>
        /// 批准
        /// </summary>
        Approved,
        /// <summary>
        /// 删除
        /// </summary>
        Del,
       
        /// <summary>
        /// 父
        /// </summary>
        Parent,
        /// <summary>
        /// 作者
        /// </summary>
        AuthorID,
        /// <summary>
        /// 作者信息
        /// </summary>
        Author,
    }
}
