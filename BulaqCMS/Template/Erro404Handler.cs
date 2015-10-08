using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Template
{
    public class Error404Handler : TemplateBaseHandler
    {
        public Error404Handler() : base(null, null) { }
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("Error : 404 <br/> Not Found This Page");
        }
    }
}