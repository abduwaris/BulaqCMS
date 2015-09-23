using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Models
{
    /// <summary>
    /// 用户参数模型
    /// </summary>
    public class UserOptionsModel
    {
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 用户 ID
        /// </summary>
        public int UserID { get; set; }

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
