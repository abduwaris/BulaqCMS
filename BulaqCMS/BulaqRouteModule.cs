using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Text.RegularExpressions;

namespace BulaqCMS
{
    public class BulaqRouteModule : IHttpModule
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            // 下面是如何处理 LogRequest 事件并为其 
            // 提供自定义日志记录实现的示例
            context.LogRequest += new EventHandler(OnLogRequest);


            //context.BeginRequest += context_BeginRequest;

            context.PostResolveRequestCache += context_PostResolveRequestCache;
            context.PostRequestHandlerExecute += context_PostRequestHandlerExecute;
            //context.Context.RemapHandler(new Index());
        }

        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {

        }

        void context_PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            if (!app.Context.Request.RawUrl.StartsWith("/Admin/", StringComparison.OrdinalIgnoreCase))
            {
                //如果是模板文件
                var req = app.Context.Request;
                if (req.RawUrl.StartsWith("/Template/", StringComparison.OrdinalIgnoreCase))
                {
                    string[] exts = { ".aspx", ".ashx", ".cshtml", ".vbhtml" };
                    //不可以执行
                    var ext = Path.GetExtension(req.FilePath);
                    if (exts.Contains(ext.ToLower()))
                    {
                        app.Context.RemapHandler(new BulaqCMS.Template.TemplateNotExeciteHandler());
                    }
                }
                else if (req.RawUrl.StartsWith("/Post/"))
                {
                    //文章
                    //Regex postReg = new Regex(@"^/post/[a-zA-Z0-9]", RegexOptions.IgnoreCase);
                }
                else if (req.RawUrl.StartsWith("/Tags/"))
                {
                    //文章
                }
                else if (req.RawUrl.StartsWith("/Category/"))
                {
                    //文章
                }

            }
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            //IHttpHandler index = new Index();
            //index.ProcessRequest(app.Context);
            //app.Context.Response.End();
            //app.Context.Server.Transfer(index, true);



        }




        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //可以在此处放置自定义日志记录逻辑
        }
    }
}
