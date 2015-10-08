using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BulaqCMS.Template
{
    public class IndexPageHandler : TemplateBaseHandler
    {

        public IndexPageHandler()
            : this("1")
        {

        }

        public IndexPageHandler(object pageIndex)
            : base(null, pageIndex)
        {

        }
        public override void ProcessRequest(HttpContext context)
        {
            //设置 QueryString
            //Set(context);
            //Set("PageIndex", PageIndex);
            string query = context.Request.QueryString.ToString();

            query += (string.IsNullOrEmpty(query) ? "" : "&") + "PageIndex=" + PageIndex;
            //执行
            context.Server.Execute("~/template/default/index.aspx?" + query, true);
        }
    }

    public static class CollectionExtension
    {
        public static void ForEach<T>(this ICollection<T> cols, Action<T> action)
        {
            foreach (var col in cols)
            {
                action(col);
            }
        }
    }
}