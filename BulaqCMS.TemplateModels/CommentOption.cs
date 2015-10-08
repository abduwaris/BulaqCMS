using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.TemplateModels
{
    public class CommentOption
    {
        #region 方法

        /// <summary>
        /// 创建 option
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public static CommentOption CreateOption(int commentId)
        {
            return new CommentOption();
        }

        #endregion

        internal CommentOption() { }

        #region 属性
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 相关评论 ID
        /// </summary>
        public int CommentID { get; set; }

        /// <summary>
        /// 参数键
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        public string Value { get; set; }

        #endregion


        #region 扩展属性

        /// <summary>
        /// 评论
        /// </summary>
        public Comment Comment { get; internal set; }

        #endregion

    }
}
