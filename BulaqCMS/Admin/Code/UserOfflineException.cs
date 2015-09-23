using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Admin
{
    public class UserOfflineException : Exception
    {
        //public UserOfflineException(HttpMethod method, HttpContentType contenttype, string url = "")
        //{
        //    this.HttpMethod = method;
        //    this.ContentType = contenttype;
        //    this.RedirectUrl = url;
        //}

        /// <summary>
        /// 当前的请求类型
        /// </summary>
        public HttpMethod HttpMethod { get; private set; }

        ///// <summary>
        ///// 返回数据类型
        ///// </summary>
        //public HttpContentType ContentType { get; private set; }

        /// <summary>
        /// 登陆成功后跳转的页面
        /// </summary>
        public string RedirectUrl { get; private set; }
    }
}