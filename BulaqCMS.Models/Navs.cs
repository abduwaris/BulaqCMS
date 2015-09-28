using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class NavsModel
    {
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 分组 ID
        /// </summary>
        public int GroupID { get; set; }

        /// <summary>
        /// 父菜单 ID
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public short Index { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        public string Url { get; set; }

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

        /// <summary>
        /// 来自
        /// 0: custom
        /// 1: post
        /// 2: categoriy
        /// 3: link
        /// 4: page
        /// 5: tag
        /// </summary>
        public short From { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }

        /// <summary>
        /// 头贴
        /// </summary>
        public string Image { get; set; }

        #region 额外参数

        /// <summary>
        /// 这个菜单所属的分组
        /// </summary>
        public NavGroupModel NavGroupe { get; set; }

        #endregion
    }
}
