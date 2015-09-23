using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    /// <summary>
    /// 评论查询排序模式
    /// </summary>
    public enum CommentOrderByMode
    {
        /// <summary>
        /// 不排序
        /// </summary>
        None,
        /// <summary>
        /// 根据ID
        /// </summary>
        ID,
        /// <summary>
        /// 根据ID
        /// </summary>
        ID_Desc,
        /// <summary>
        /// 发表时间
        /// </summary>
        WriteTime,
        /// <summary>
        /// 发表时间
        /// </summary>
        WriteTime_Desc,
        /// <summary>
        /// 是否批准
        /// </summary>
        Approved,
        /// <summary>
        /// 是否批准
        /// </summary>
        Approved_Desc,
        /// <summary>
        /// 删除表示
        /// </summary>
        Del,
        /// <summary>
        /// 删除表示
        /// </summary>
        Del_Desc,
       
        /// <summary>
        /// 文章
        /// </summary>
        Post,
        /// <summary>
        /// 文章
        /// </summary>
        Post_Desc
    }
}
