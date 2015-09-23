using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 链接模型
    /// </summary>
    public class LinksModel
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
        /// 链接目标
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public short Index { get; set; }

        /// <summary>
        /// 链接图片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }

        /// <summary>
        /// 打开方式
        /// 1: _none
        /// 2: _blank
        /// 3: _top
        /// 4: _self
        /// 5: _parent
        /// </summary>
        public short Target { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Visible { get; set; }
    }
}
