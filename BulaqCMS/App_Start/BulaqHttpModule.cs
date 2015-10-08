using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BulaqCMS
{
    public class BulaqHttpModule : IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication app)
        {
            app.PostResolveRequestCache += app_PostResolveRequestCache;
        }

        void app_PostResolveRequestCache(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var url = app.Context.Request.RawUrl;
            var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(app.Context));
        }
    }
}