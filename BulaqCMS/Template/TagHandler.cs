using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;

namespace BulaqCMS.Template
{
    public class TagHandler : TemplateBaseHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }
        public TagHandler()
            : base(null, null)
        {

        }
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("TagHandler");
        }
    }

    public static class HttpContextExtension
    {
        public static void Set(this HttpContextBase context, string key, object value)
        {
            
        }
    }
}