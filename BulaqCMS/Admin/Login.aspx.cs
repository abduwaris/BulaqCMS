using BulaqCMS.BLL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        ServiceSession Service
        {
            get
            {
                return BLLServiceFactory.CreateServiceSession();
            }
        }

        bool needValidateCode = true;

        protected bool hasUrl = false;
        protected string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["url"]))
            {
                hasUrl = true;
                url = Uri.UnescapeDataString(Request.QueryString["url"].Trim());
            }
            string error = "";
            bool isOk = false;
            if (Session[AdminBasePage.OnlineUserInSession] != null)
            {
                if (Request.HttpMethod == "POST") error = "online";
                else Response.Redirect("Main.aspx");
            }
            if (Request.HttpMethod == "POST")
            {
                if (error != "online")
                {
                    string userName = Request.Form["UserName"];
                    string pass = Request.Form["Password"];
                    string validate = Request.Form["ValidateCode"];

                    if (userName != null && pass != null)
                    {
                        if (needValidateCode && validate == null) error = "data_null";
                        else if (needValidateCode && Session[AdminBasePage.ImageCodeInSession] == null) error = "validate_code";
                        else if (needValidateCode && Session[AdminBasePage.ImageCodeInSession].ToString().ToLower() != validate.ToLower()) error = "validate_code";
                        else
                        {
                            UsersModel user = Service.UsersService.Login(userName, pass);
                            if (user == null) error = "user_or_pass";
                            else
                            {
                                isOk = true;
                                Session.Remove("ValidateCode");
                                Session[AdminBasePage.OnlineUserInSession] = user;
                            }
                        }
                    }
                    else error = "data_null";
                }
                Response.Write("{\"result\":\"{result}\"{error}}".Replace("{result}", isOk ? "ok" : "no").Replace("{error}", isOk ? "" : ",\"error\":\"{error}\"".Replace("{error}", error)));
                Response.End();
            }
        }
    }
}