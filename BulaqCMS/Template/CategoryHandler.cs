using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Template
{
    public class CategoryHandler : IHttpHandler
    {

        public CategoryHandler() : this(false) { }

        public CategoryHandler(bool undified) { }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("CategoryHandler");
        }
    }
}