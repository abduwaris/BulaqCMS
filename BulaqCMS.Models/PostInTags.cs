using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 文章标签关系模型
    /// </summary>
    public class PostInTagsModel
    {
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 文章 ID
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// 标签 ID
        /// </summary>
        public int TagID { get; set; }
    }
}
