using BulaqCMS.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace BulaqCMS
{
    public class BulaqRouteHandler : IRouteHandler
    {

        private RouteHandlerMode Mode { get; set; }

        public BulaqRouteHandler()
            : this(RouteHandlerMode.Default)
        {

        }
        public BulaqRouteHandler(RouteHandlerMode mode)
        {
            this.Mode = mode;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        
        {
            var routeData = requestContext.RouteData;
            var prev = routeData.Values["prev"];
            var tocken = routeData.DataTokens;
            var pageIndex = routeData.Values["pageIndex"];
            var otherName = routeData.Values["othername"];
            if (prev == null)
                return new Template.IndexPageHandler(pageIndex);
            else
            {
                var p = prev.ToString().ToLower();
                if (p == "post")
                {
                    return new PostHandler(otherName, pageIndex);
                }
                if (p == "index")
                {
                    return new IndexPageHandler(pageIndex);
                }
                if (p == "category")
                {
                    return new CategoryHandler();
                }
                if (p == "tag")
                {
                    return new TagHandler();
                }
                if (p == "template")
                {
                    return new TemplateNotExeciteHandler();
                }
                if (p == "search")
                {
                    return new SearchHandler();
                }
                else
                {
                    return new Error404Handler();
                }
            }


        }
    }

    public enum RouteHandlerMode
    {
        /// <summary>
        /// 首页
        /// </summary>
        Default,
        /// <summary>
        /// 文章也
        /// </summary>
        Post,
        /// <summary>
        /// 专辑页
        /// </summary>
        Category,
        /// <summary>
        /// 标签页
        /// </summary>
        Tags,
        /// <summary>
        /// 搜索页
        /// </summary>
        Search,
        /// <summary>
        /// 静态页
        /// </summary>
        Page,

        /// <summary>
        /// 模板
        /// </summary>
        Template,
    }
}