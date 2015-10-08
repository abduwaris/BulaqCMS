using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BulaqCMS.App_Start
{
    public class BulaqRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData data = new RouteData(this, new BulaqRouteHandler(RouteHandlerMode.Default));
            return data;

            //System.Web.Routing.UrlRoutingModule mode = new UrlRoutingModule();
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            throw new NotImplementedException();
        }
    }
}