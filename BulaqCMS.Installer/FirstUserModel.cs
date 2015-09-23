using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Installer
{
    /// <summary>
    /// 数据库创建用户模型
    /// </summary>
    public class FirstUserModel
    {
        /// <summary>
        ///登录名, Not Null
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 名称, Null
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 密码,Not Null
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 邮箱, Null
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 昵称, Null
        /// </summary>
        public string NiceName { get; set; }
        /// <summary>
        /// 网址, Null
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 网址, Null
        /// </summary>
        public string WebSite { get; set; }
    }
}
