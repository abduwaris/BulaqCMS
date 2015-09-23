using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 文章类别模型
    /// </summary>
    public class CategoriesModel
    {
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 主题 Guid
        /// </summary>
        public string ThemeGuid { get; set; }

        /// <summary>
        /// 父
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }


        #region 额外参数

        /// <summary>
        /// 在这个专辑下的所有文章集合
        /// </summary>
        public ICollection<PostsModel> Posts { get; set; }

        /// <summary>
        /// 在这个专辑下的所有文章个数
        /// </summary>
        public int PostsCount { get; set; }

        #endregion
    }
}
