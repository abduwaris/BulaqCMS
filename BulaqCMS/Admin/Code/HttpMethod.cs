using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Admin
{
    /// <summary>
    /// 请求方法
    /// </summary>
    public enum HttpMethod
    {
        /// <summary>
        /// get 请求
        /// </summary>
        HttpGet,
        /// <summary>
        /// post 请求
        /// </summary>
        HttpPost,
        /// <summary>
        /// delete , put, push, header 请求
        /// </summary>
        HttpOther
    }
}