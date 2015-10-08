using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using BulaqCMS.BLL;
using System.Dynamic;

namespace BulaqCMS
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    public class Index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            BulaqCMS.BLL.ServiceSession Service = BulaqCMS.BLL.BLLServiceFactory.CreateServiceSession();

            context.Response.ContentType = "text/html";
            //context.Response.Write("Hello World");
            //string template = File.ReadAllText(context.Server.MapPath("~/Template/default/index.cshtml"), System.Text.Encoding.UTF8);

            ////dynamic model = new object();
            //Dictionary<string, object> dic = new Dictionary<string, object>();

            //int totalCount = 1;
            //dic["Posts"] = Service.PostsService.GetPostsByPage(10, 1, out totalCount, true);
            //dic["PageIndex"] = 1;
            //dic["PageCount"] = Convert.ToInt32(Math.Ceiling(totalCount / 10.0));

            //string result = TemplateParser.ExecuteIndex(template, dic);
            //context.Response.Write(result);

            context.Server.Execute("~/Template/Default/index.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}