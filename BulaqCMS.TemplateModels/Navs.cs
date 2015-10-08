using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.TemplateModels
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class NavGroup
    {
        /// <summary>
        /// 主键
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
        /// 描述
        /// </summary>
        public string Des { get; set; }

        #region 额外参数

        /// <summary>
        /// 这个分组下的所有菜单
        /// </summary>
        public ICollection<Nav> Navs { get; set; }

        /// <summary>
        /// 菜单个数
        /// </summary>
        public int NavsCount { get; set; }

        #endregion
    }
}
