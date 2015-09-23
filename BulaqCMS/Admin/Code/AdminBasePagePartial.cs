using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Admin
{
    public partial class AdminBasePage
    {
        /// <summary>
        /// 将对象转换成标准的 HTMLString 返回
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected HtmlString Html(object obj)
        {
            return new HtmlString(obj.ToString());
        }

        /// <summary>
        /// string.isNullOrEmpty 函数简写
        /// </summary>
        /// <param name="checkStr"></param>
        /// <returns></returns>
        protected bool stringNull(string checkStr)
        {
            return string.IsNullOrEmpty(checkStr);
        }


        #region Url 操作

        Dictionary<string, object> _queryString;

        /// <summary>
        /// Url 参数集合
        /// </summary>
        protected Dictionary<string, object> QueryString
        {
            get
            {
                if (_queryString == null) _queryString = new Dictionary<string, object>();
                return _queryString;
            }
            set
            {
                _queryString = value;
            }
        }

        /// <summary>
        /// 创建 URL 参数
        /// </summary>
        /// <param name="key">Url 参数key</param>
        /// <param name="value">URL 参数值</param>
        /// <returns></returns>
        protected HtmlString CreateQueryString(string key, object value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>(_queryString);
            dic[key] = value;
            return new HtmlString(string.Join("&", dic.Select(p => p.Key + "=" + p.Value)));
        }

        /// <summary>
        ///根据 URL 生成参数
        /// </summary>
        /// <param name="url">没有参数的Url</param>
        /// <returns></returns>
        protected HtmlString CreateQueryString(string url)
        {
            return new HtmlString(url + "?" + string.Join("&", _queryString.Select(p => p.Key + "=" + p.Value)));
        }

        /// <summary>
        /// 创建 Url
        /// </summary>
        /// <param name="url">没有参数的Url</param>
        /// <param name="key">参数Key</param>
        /// <param name="value">参数value</param>
        /// <returns></returns>
        protected HtmlString CreateQueryString(string url, string key, object value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>(_queryString);
            dic[key] = value;
            return new HtmlString(url + "?" + string.Join("&", dic.Select(p => p.Key + "=" + p.Value)));
        } 
        #endregion
    }
}