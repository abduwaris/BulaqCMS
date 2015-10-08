using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace BulaqCMS
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //判断程序是否安装
            //注册路由
            RouteConfig.RegisterRoute(RouteTable.Routes);

            //this.PostResolveRequestCache += Global_PostResolveRequestCache;
        }

        void Global_PostResolveRequestCache(object sender, EventArgs e)
        {
            //var url = ((HttpApplication)sender).Context.Request.RawUrl;
        }
    }
}