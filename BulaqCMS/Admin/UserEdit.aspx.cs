using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BulaqCMS.Common;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace BulaqCMS.Admin
{
    public partial class UserEdit : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Mode = Request.QueryString["mode"] ?? "new";
        }
        public override string ActivePage
        {
            get
            {
                return "user-add";
            }
        }

        /// <summary>
        /// 当前页面方式
        /// new 添加用户
        /// edit 修改用户属性
        /// del 删除用户
        /// </summary>
        protected string Mode { get; set; }

        /// <summary>
        /// 当开始时,获取数据
        /// </summary>
        /// <param name="context"></param>
        public override void ProcessRequest(HttpContext context)
        {
            //判断是不是 Post 过来
            if (Method == HttpMethod.HttpPost && IsOnline)
            {
                var req = context.Request;
                //获取mode
                string mode = req.Form["mode"];
                if (mode == "edit" || mode == "new")
                {

                    //新建用户
                    //UsersModel user = new UsersModel();
                    List<string> errors = new List<string>();
                    bool isOk = false;
                    int userId = 0;
                    if (mode == "edit" && (req.Form["UserID"] == null || !int.TryParse(req["UserID"], out userId))) errors.Add("userid_null");
                    if (mode == "new" && string.IsNullOrEmpty(req.Form["Email"])) errors.Add("email_null");
                    if (!string.IsNullOrEmpty(req.Form["Email"]) && !Regex.IsMatch(req.Form["Email"], Validater.Email)) errors.Add("email_format");
                    if (mode == "new" && req.Form["LoginName"] == null) errors.Add("loginname_null");
                    if (mode == "new" && !Regex.IsMatch(req.Form["LoginName"], Validater.LoginName)) errors.Add("loginname_format");
                    if (mode == "new" && string.IsNullOrEmpty(req.Form["Password"])) errors.Add("password_null");
                    if (!string.IsNullOrEmpty(req.Form["Password"]) && !Regex.IsMatch(req.Form["Password"], Validater.Password)) errors.Add("password_format");
                    if (!string.IsNullOrEmpty(req.Form["Password"]) && (req.Form["ConfirmPassword"] == null || req.Form["Password"] != req.Form["ConfirmPassword"])) errors.Add("confirm_password");
                    if (!string.IsNullOrEmpty(req.Form["Website"]) && !Regex.IsMatch(req.Form["Website"], Validater.Website)) errors.Add("website_format");
                    if (mode == "new" && string.IsNullOrEmpty(req.Form["NiceName"])) errors.Add("nicename_null");
                    //开始
                    if (errors.Count <= 0)
                    {
                        UsersModel user = mode == "new" ? new UsersModel() : Service.UsersService.One(userId);
                        if (mode == "edit" && user == null) errors.Add("user_null");
                        else
                        {
                            //开始刷数据
                            user.Email = string.IsNullOrEmpty(req.Form["Email"]) ? user.Email : req.Form["Email"];
                            user.DisplayName = string.IsNullOrEmpty(req.Form["DisplayName"]) ? (user.DisplayName ?? "") : req.Form["DisplayName"];
                            user.NiceName = string.IsNullOrEmpty(req.Form["NiceName"]) ? user.NiceName ?? "" : req.Form["NiceName"];
                            user.Password = string.IsNullOrEmpty(req.Form["Password"]) ? user.Password : PasswordHelper.CreateBulaqPassword(req.Form["Password"]);
                            user.RegisterTime = mode == "new" ? DateTime.Now : user.RegisterTime;
                            user.Url = string.IsNullOrEmpty(req.Form["Website"]) ? user.Url ?? "" : req.Form["Website"];
                            if (mode == "edit")
                            {
                                user.ID = userId;
                                isOk = Service.UsersService.Update(user, errors);
                            }
                            else
                            //(mode == "new")
                            {
                                user.LoginName = req.Form["LoginName"];
                                isOk = Service.UsersService.CreateUser(user, errors);
                            }
                        }
                    }
                    //写入 Json
                    if (ResponseType == ResponseDataType.Json) context.Response.Write(JsonConvert.SerializeObject(isOk ? (object)new { result = "ok" } : new { result = "no", errors = errors }));
                    ///XML
                    else if (ResponseType == ResponseDataType.Xml)
                    {
                        XmlSerializer seria = new XmlSerializer(typeof(ResponseResult));
                        using (TextWriter st = new StringWriter())
                        {
                            ResponseResult res = new ResponseResult() { Result = isOk ? "ok" : "no", Errors = errors };
                            seria.Serialize(st, res);
                            context.Response.Write(st.ToString());
                        }
                    }
                    return;
                }
            }
            base.ProcessRequest(context);
        }
    }
}