using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 文章参数模型
    /// </summary>
    public class PostOptionsModel
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
        /// 参数 键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 参数 值
        /// </summary>
        public string Value { get; set; }
    }
}
