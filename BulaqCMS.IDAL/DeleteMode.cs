using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    /// <summary>
    /// 模式, 用于 Post 关系表
    /// </summary>
    public enum ModifiedMode
    {
        /// <summary>
        /// 根据自己的ID
        /// </summary>
        Self,
        /// <summary>
        /// 根据标签 或者 专辑
        /// </summary>
        TagOrCategoriy,
        /// <summary>
        /// 根据文章
        /// </summary>
        Post
    }
}
