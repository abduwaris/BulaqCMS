using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using BulaqCMS.BLL;
using BulaqCMS.Models;
using Newtonsoft.Json;
using HtmlAgilityPack;
namespace BulaqCMS.Admin
{
    public partial class AdminBasePage : Page, IRequiresSessionState
    {
        #region Const String

        public const string OnlineUserInSession = "OnlineUser";
        public const string ImageCodeInSession = "ImageCode";

        #endregion

        private HttpContext __context = null;
        /// <summary>
        /// 全局的 HttpContext
        /// </summary>
        protected HttpContext _Context
        {
            get
            {
                if (__context == null) __context = this.Context;
                return __context;
            }
        }
        /// <summary>
        /// 当前语言代码
        /// </summary>
        public string Languege { get; private set; }

        /// <summary>
        /// 判断用户是否在线
        /// </summary>
        public bool IsOnline
        {
            get
            {
                return _Context.Session[OnlineUserInSession] != null && _Context.Session[OnlineUserInSession] is UsersModel;
            }
        }
        /// <summary>
        /// 当前在线用户
        /// </summary>
        public UsersModel OnlineUser { get { return _Context.Session[OnlineUserInSession] as UsersModel ?? new UsersModel(); } }

        /// <summary>
        /// 当前的活动页面
        /// </summary>
        public virtual string ActivePage { get { return "main"; } }


        private Nullable<HttpMethod> __method;
        /// <summary>
        /// 是不是 Post 过来的
        /// </summary>
        protected HttpMethod Method
        {
            get
            {
                if (__method == null)
                {
                    switch (this._Context.Request.HttpMethod.ToUpper())
                    {
                        case "POST": __method = HttpMethod.HttpPost;
                            break;
                        case "GET": __method = HttpMethod.HttpGet;
                            break;
                        default: __method = HttpMethod.HttpOther;
                            break;
                    }
                }
                return (HttpMethod)__method;
            }
        }

        private Nullable<ResponseDataType> __contentType;
        /// <summary>
        /// 客户端数据类型
        /// </summary>
        protected ResponseDataType ResponseType
        {
            get
            {
                //XML  application/xml;  text/xml; 
                //Json application/json;  text/javascript; 
                //Script  text/javascript   application/javascript  application/ecmascript  application/x-ecmascript 
                //Html  text/html    
                //Text  text/plain  
                if (__contentType == null)
                {
                    string[] accs = _Context.Request.AcceptTypes;
                    if (accs.Count(p => p.ToLower() == "application/xml") > 0 && accs.Count(p => p.ToLower() == "text/xml") > 0) __contentType = ResponseDataType.Xml;
                    else if (accs.Count(p => p.ToLower() == "text/javascript") > 0 && accs.Count(p => p.ToLower() == "application/json") > 0) __contentType = ResponseDataType.Json;
                    else if (accs.Count(p => p.ToLower() == "text/javascript") > 0 && accs.Count(p => p.ToLower() == "application/javascript" || p.ToLower() == "application/ecmascript" || p.ToLower() == "application/x-ecmascript") > 0) __contentType = ResponseDataType.Script;
                    else if (accs.Count(p => p.ToLower() == "text/html") > 0) __contentType = ResponseDataType.Html;
                    else if (accs.Count(p => p.ToLower() == "text/plain") > 0) __contentType = ResponseDataType.Text;
                    else __contentType = ResponseDataType.Other;
                }
                return (ResponseDataType)__contentType;
            }
        }
        /// <summary>
        /// 逻辑层操作
        /// </summary>
        public ServiceSession Service
        {
            get
            {
                return BLLServiceFactory.CreateServiceSession();
            }
        }

        /// <summary>
        /// 客户端返回码
        /// </summary>
        protected ResponseResult Result { get; set; }


        protected override void Construct()
        {
            Result = new ResponseResult();
            base.Construct();
        }

        public override void ProcessRequest(HttpContext context)
        {
            //设置头部
            this.__context = context;
            //设置语言
            this.Languege = "ug-cn";

            //判断用户是否登陆
            if (!IsOnline)
            {
                //判断是否Json格式
                if (ResponseType == ResponseDataType.Json)
                {
                    if (ResponseType == ResponseDataType.Json && !IsOnline)
                        context.Response.Write(JsonConvert.SerializeObject(Result.SetError("offline"), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
                }
                //判断是否是 XML
                else
                {
                    //浏览器访问
                    string esca = Uri.EscapeDataString(context.Request.Url.ToString());
                    context.Response.Redirect(string.Format("Login.aspx{0}", context.Request.Url.LocalPath.ToLower() != "/admin/login.aspx" ? ("?url=" + esca) : ""));
                }
                Response.End();
            }
            else
            {
                //判断用户返回的是不是
                base.ProcessRequest(context);
                ////如果是 Json 并且是 Post
                //if (ResponseType == ResponseDataType.Json && Method == HttpMethod.HttpPost)
                //{
                //    context.Response.Write(JsonConvert.SerializeObject(Result, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
                //}
            }

        }

        protected override void OnInit(EventArgs e)
        {
            //如果是 Json 并且是 Post
            if (ResponseType == ResponseDataType.Json && Method == HttpMethod.HttpPost)
            {
                Response.Write(JsonConvert.SerializeObject(Result, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
                Response.End();
            }
            base.OnInit(e);
        }

        /// UBB Editor
        /// [a h"<href>" t="<target>"]<words>[/a] 超链接
        /// [align <c[center]|r[right]|l[left]|j[justfy]>]<words>[/align] 对其
        /// [b]<words>[/b] 粗体
        /// [c <hash>]<words>[/c] 颜色
        /// [code <lang>]<code words>[/code] 代码
        /// [d]<words>[/d]  删除线
        /// [dir <direction[r[rtl]|l[ltr]|d[default]]>]<words>[/dir] 方向
        /// [f "<font-name>"]<words>[/f] 字体
        /// [h<size[1-6]>]<words>[/h] h 标签(标题)
        /// [hr /] 横线
        /// [i]<words>[/i]  斜体
        /// [m s="<src>" /] 表情 自闭标签
        /// [p s="<src>" h="<height[px]>" w="<width[px]>"/]  图片
        /// [s <size[px]>]<words>[/s]  字号
        /// [table]<tbody|thead|tr>[/t] table 表格
        /// [td c="<[colspan]number>" r="<[rowspan]number>"][/td] td
        /// [tr][/tr] tr
        /// [u]<words>[/u]  下划线
        /// 


    }
}