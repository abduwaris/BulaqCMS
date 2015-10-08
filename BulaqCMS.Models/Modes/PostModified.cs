using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{

    public enum PostModified
    {
        /// <summary>
        /// 保存
        /// </summary>
        Save,
        /// <summary>
        /// 发表
        /// </summary>
        Visible,
        /// <summary>
        /// 设置头贴
        /// </summary>
        Image,
        /// <summary>
        /// 批准
        /// </summary>
        Approve,
        /// <summary>
        /// 删除表示
        /// </summary>
        DelFlag,
        /// <summary>
        /// 草稿
        /// </summary>
        Practice,

        /// <summary>
        /// 修改别名
        /// </summary>
        Rename
    }
}
