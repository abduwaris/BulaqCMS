using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 文章,专辑关系表
    /// </summary>
    public class PostInCategoriesModel
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
        /// 专辑 ID
        /// </summary>
        public int CategoryID { get; set; }
    }
}
