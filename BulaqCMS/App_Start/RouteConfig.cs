using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;

namespace BulaqCMS
{
    public static class RouteConfig
    {
        /// <summary>
        /// 页前缀
        /// </summary>
        public const string PREV = @"^(index)|(post)|(template)|(category)|(tag)|(search)|(page)$";

        /// <summary>
        /// 别名
        /// </summary>
        public const string OTHER_NAME = @"^((?!\S*?[\.])(?!\S*?[\-_\.]{2,})[a-zA-Z0-9\-\._]{0,}[^\.])?$";

        /// <summary>
        /// 页码
        /// </summary>
        public const string PAGE_INDEX = @"^([1-9][\d+]{0,10})?$";

        public static void RegisterRoute(RouteCollection route)
        {

            route.RouteExistingFiles = true;
            route.LowercaseUrls = true;
            route.Ignore("{resource}.ashx/{*pathInfo}");
            route.Ignore("{resource}.axd/{*pathInfo}");

            RouteValueDictionary defaultValue = new RouteValueDictionary { { "pages", "login.aspx" } };
            RouteValueDictionary contains = new RouteValueDictionary { { "pages", @"[a-zA-Z0-9/]*" } };

            //route.Add("ashx", new Route("{path}.ashx", new PageRouteHandler("~/{path}.ashx")));
            //管理员页面
            route.MapPageRoute(
                "admin-login",
                "admin/",
                "~/admin/login.aspx",
                true
                );

            route.MapPageRoute(
                "admin",
                "admin/{pages}.aspx",
                "~/admin/{pages}.aspx",
                true,
                defaultValue, contains
                );

            route.MapPageRoute(
                "admin2",
                "admin/{pages}",
                "~/admin/{pages}.aspx",
                true,
                defaultValue, contains
                );


            //route.Add("admin", new Route("admin/", new AdminRouteHandler()));

            RouteValueDictionary pageIndex = new RouteValueDictionary { { "pageIndex", "1" } };
            RouteValueDictionary pageIndexC = new RouteValueDictionary { { "pageIndex", @"^[1-9][0-9]{0,10}$" } };

            RouteValueDictionary otherName = new RouteValueDictionary { { "othername", "" } };
            RouteValueDictionary otherNameC = new RouteValueDictionary { { "othername", @"^((?!\S*?[\.])(?!\S*?[\-_\.]{2,})[a-zA-Z0-9\-\._]{0,}[^\.])?$" } };

            RouteValueDictionary all = new RouteValueDictionary { 
                 { "prev", "" }, 
                 { "pageIndex", "1" }, 
                 { "othername", "" } 
            };
            RouteValueDictionary allC = new RouteValueDictionary { 
                { "prev", PREV },
                {"pageIndex",PAGE_INDEX},
                {"othername",OTHER_NAME}
            };

            var p = new RouteValueDictionary(otherName.Union(pageIndex));

            //首页
            route.Add(
                "default",
                new Route("", new BulaqRouteHandler())
                );

            //route.Add(
            //     "alll1", new Route("{prev}/{pageIndex}", all, allC, new BulaqRouteHandler())
            //    );
            route.Add(
                 "defaultRoute1", new Route("{pageIndex}", new RouteValueDictionary { { "pageIndex", "1" } }, new RouteValueDictionary { { "pageIndex", PAGE_INDEX } }, allC, new BulaqRouteHandler())
                );

            route.Add(
                 "defaultRoute", new Route("{prev}/{othername}/{pageIndex}", all, allC, new BulaqRouteHandler())
                );


            //自定义页面
            route.Add("custompage", new Route("{othername}", otherName, otherNameC, new BulaqRouteHandler()));

        }
    }
}