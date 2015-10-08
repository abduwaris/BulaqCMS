using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BulaqCMS.Template
{
    public class PostHandler : TemplateBaseHandler
    {

        #region 构造函数
        public PostHandler()
            : this(null, 1)
        {

        }

        public PostHandler(object postName, object pageIndex)
            : base(postName, pageIndex)
        {

        }
        #endregion

        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //context.Response.Write("PostHandler</br>");
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(context));
            if (routeData != null)
            {
                context.Response.Write("Post Name : " + routeData.Values["othername"] + "</br>");
                context.Response.Write("Page Index : " + routeData.Values["pageIndex"] + "</br>");
            }

            //StringWriter sw = new StringWriter();
            try
            {
                context.Server.Execute(string.Format("~/Template/{0}/index.aspx", "default"), true);
            }
           
            catch (Exception e)
            {

                //throw e;
            }

            //context.Response.out
        }
    }
}