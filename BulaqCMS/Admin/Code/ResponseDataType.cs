using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Admin
{
    /// <summary>
    /// 客户端请求数据类型
    /// </summary>
    public enum ResponseDataType
    {
        /// <summary>
        /// 请求 Json 数据
        /// </summary>
        Json,
        /// <summary>
        /// 请求 Html 数据
        /// </summary>
        Html,
        /// <summary>
        /// 请求 XML 数据
        /// </summary>
        Xml,
        /// <summary>
        /// 脚本
        /// </summary>
        Script,
        /// <summary>
        /// 文本
        /// </summary>
        Text,
        /// <summary>
        /// 请求其他数据
        /// </summary>
        Other
    }
}