using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 文章排序方式
    /// </summary>
    public enum PostsOrderByMode
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
        /// 作者排序
        /// </summary>
        Author,
        /// <summary>
        /// 作者排序
        /// </summary>
        Author_Desc,
        /// <summary>
        /// 创建时间
        /// </summary>
        CreateTime,
        /// <summary>
        /// 创建时间
        /// </summary>
        CreateTime_Desc,
        /// <summary>
        /// 发表时间
        /// </summary>
        SendTime,
        /// <summary>
        /// 发表时间
        /// </summary>
        SendTime_Desc,
        /// <summary>
        /// IP
        /// </summary>
        IP,
        /// <summary>
        /// IP
        /// </summary>
        IP_Desc,
        /// <summary>
        /// 显示方式
        /// </summary>
        VisibleState,
        /// <summary>
        /// 显示方式
        /// </summary>
        VisibleState_Desc,
        /// <summary>
        /// 是否可以发表评论
        /// </summary>
        CanComment,
        /// <summary>
        /// 是否可以发表评论
        /// </summary>
        CanComment_Desc,
        /// <summary>
        /// 是否需要密码
        /// </summary>
        PasswordState,
        /// <summary>
        /// 是否需要密码
        /// </summary>
        PasswordState_Desc,
        /// <summary>
        /// 主题
        /// </summary>
        ThemeGuid,
        /// <summary>
        /// 主题
        /// </summary>
        ThemeGuid_Desc,
        /// <summary>
        /// 删除标识
        /// </summary>
        DelFlag,
        /// <summary>
        /// 删除标识
        /// </summary>
        DelFlag_Desc,
        /// <summary>
        /// 批准
        /// </summary>
        Approved,
        /// <summary>
        /// 批准
        /// </summary>
        Approved_Desc,
    }
}
