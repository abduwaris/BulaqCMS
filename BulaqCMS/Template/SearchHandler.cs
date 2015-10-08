using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Template
{
    public class SearchHandler : TemplateBaseHandler
    {
        public SearchHandler()
            : base(null, null)
        {

        }

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("SearchHandler");
            context.Request.QueryString["hehe"] = "hehe";
        }
    }
}