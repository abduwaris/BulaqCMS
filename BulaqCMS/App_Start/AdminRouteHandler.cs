using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BulaqCMS
{
    public class AdminRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return requestContext.RouteData.RouteHandler.GetHttpHandler(requestContext);
        }
    }
}