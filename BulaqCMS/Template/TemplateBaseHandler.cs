using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace BulaqCMS.Template
{
    public abstract class TemplateBaseHandler : IHttpHandler
    {
        /// <summary>
        /// 页码
        /// </summary>
        protected int PageIndex { get; private set; }
        /// <summary>
        /// 别名
        /// </summary>
        protected string OtherName { get; private set; }

        protected IDictionary<string, object> QueryString { get; set; }

        public TemplateBaseHandler(object otherName, object pageIndex)
        {
            this.QueryString = new Dictionary<string, object>();
            this.OtherName = otherName == null ? null : otherName.ToString();
            //int pageI = 1;
            int pageI = int.TryParse(pageIndex == null ? "1" : pageIndex.ToString(), out pageI) && pageI > 0 ? pageI : 1;
            PageIndex = pageI;
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public abstract void ProcessRequest(HttpContext context);

        /// <summary>
        /// 设置 QueryString
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void Set(string key, object value)
        {
            if (string.IsNullOrEmpty(key)) return;
            QueryString.Add(key, value);
        }

        /// <summary>
        /// 设置 QueryString
        /// </summary>
        protected void Set(HttpContext context)
        {
            if (context == null) return;
            var req = context.Request.QueryString;
            var keys = req.Keys;
            for (int i = 0; i < keys.Count; i++)
            {
                var values = req.GetValues(i);
                foreach (var val in values)
                {
                    QueryString.Add(keys[i], val);
                }
            }
        }

        /// <summary>
        /// 获取 QueryString
        /// </summary>
        protected string Get()
        {
            return string.Join("&", QueryString.Select(p => string.Format("{0}={1}", p.Key, p.Value)));
        }

        private NameValueCollection _QueryString { get; set; }
    }
}