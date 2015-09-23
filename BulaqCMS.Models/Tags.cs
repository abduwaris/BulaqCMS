using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 标签模型
    /// </summary>
    public class TagsModel
    {
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }

        #region 额外参数

        /// <summary>
        /// 该标签下所有文章
        /// </summary>
        public ICollection<PostsModel> Posts { get; set; }

        /// <summary>
        /// 获取该标签所被使用的文章个数
        /// </summary>
        public int PostsCount { get; set; }

        #endregion
    }
}
