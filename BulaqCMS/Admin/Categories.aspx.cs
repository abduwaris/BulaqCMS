using BulaqCMS.Common;
using BulaqCMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class Categories : AdminBasePage
    {
        protected List<CategoriesModel> Cats;

        protected CategoriesModel updateCat = null;
        protected bool isEdit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Cats = Service.CategoriesService.GetList(true);
            string mode = string.IsNullOrEmpty(Request.QueryString["mode"]) ? "new" : Request.QueryString["mode"].ToLower().Trim();
            if (mode == "edit")
            {
                int cid = 0;
                if (int.TryParse(Request.QueryString["cid"].Trim(), out cid))
                {
                    //获取
                    updateCat = Service.CategoriesService.One(cid);
                    if (updateCat != null) isEdit = true;//修改
                }
            }
        }

        public override string ActivePage
        {
            get
            {
                return "post-cats";
            }
        }

        string html = "";
        protected HtmlString Options(List<CategoriesModel> childs, int nodeCount, bool hasSelect, int selectedId)
        {
            string prev = "";
            for (int i = 0; i < nodeCount; i++) prev += "&nbsp;&nbsp;&nbsp;";
            if (nodeCount > 0) prev += "┫ ";
            foreach (var chi in childs)
            {
                if (isEdit)
                    if (chi.ID == updateCat.ID || chi.ParentID == updateCat.ID)
                        continue;
                html += string.Format("<option value=\"{0}\"{3}>{1}{2}</option>", chi.ID, prev, chi.Title, hasSelect && chi.ID == selectedId ? " selected=\"selected\"" : "");
                if (Cats.Count(p => p.ParentID == chi.ID) > 0) Options(Cats.Where(p => p.ParentID == chi.ID).ToList(), nodeCount + 1, hasSelect, selectedId);
            }
            return new HtmlString(html);
        }

        string htm = "";
        protected HtmlString Lists(List<CategoriesModel> childs, int nodeCount)
        {
            string prev = "";
            for (int i = 0; i < nodeCount; i++) prev += "&nbsp;&nbsp;&nbsp;";
            if (nodeCount > 0) prev += "┫ ";
            foreach (var chi in childs)
            {
                htm += "<tr><td class=\"tools-p\">" +
                    prev + chi.Title +
                    "<div class=\"tools\">" +
                    "<div class=\"btn-group\">" +
                    "<a href=\"?mode=edit&cid=" + chi.ID +
                    "\" class=\"btn btn-primary btn-xs\">تەھرىرلەش</a>" +
                    "<input type=\"button\" name=\"name\" value=\"تىز تەھرىرلەش\" class=\"btn btn-info btn-xs\" onclick=\"quickEdit(this," + chi.ID + ");\"/>" +
                    "<input type=\"button\" name=\"name\" value=\"ئۆچۈرۈش\" class=\"btn btn-danger btn-xs\" onclick=\"_delete(" + chi.ID + ");\"/>" +
                    "<input type=\"button\" name=\"name\" value=\"كۆرۈش\" class=\"btn btn-default btn-xs\" />" +
                    "</div></div></td>" +
                    "<td>" + chi.Name +
                    "</td><td>" + chi.Des +
                    "</td><td><a href=\"#\" class=\"badge\">" + chi.PostsCount +
                    "</a></td>" +
                    "</tr>";
                if (Cats.Count(p => p.ParentID == chi.ID) > 0) Lists(Cats.Where(p => p.ParentID == chi.ID).ToList(), nodeCount + 1);
            }
            return new HtmlString(htm);
        }

        public override void ProcessRequest(HttpContext context)
        {
            if (Method == HttpMethod.HttpPost && IsOnline)
            {
                /// mode
                ///     new 默认 新增
                ///     edit 全集编辑
                ///     quick   快速编辑
                ///     delete  删除
                ///     
                //开始获取
                List<string> errors = new List<string>();
                bool isOk = false;
                var req = context.Request;
                var mode = req.Form["Mode"].ToLower().Trim();
                int cid = 0;
                //新增
                if (mode == "new")
                {
                    if (req.Form["Title"] == null) errors.Add("title_null");
                    if (!string.IsNullOrEmpty(req.Form["Name"]) && !Regex.IsMatch(req.Form["Name"], Validater.OtherName)) errors.Add("name_format");
                    CategoriesModel cat = new CategoriesModel();
                    cat.Title = string.IsNullOrEmpty(req.Form["Title"]) ? cat.Title : req.Form["Title"].Trim();
                    cat.Name = string.IsNullOrEmpty(req.Form["Name"]) ? string.Empty : req.Form["Name"].Trim();
                    cat.ThemeGuid = string.IsNullOrEmpty(req.Form["Template"]) ? string.Empty : req.Form["Template"].Trim();
                    cat.Des = string.IsNullOrEmpty(req.Form["Des"]) ? "" : req.Form["Des"].Trim();
                    if (!string.IsNullOrEmpty(req.Form["Parent"]) && int.TryParse(req.Form["Parent"].Trim(), out cid)) cat.ParentID = cid;
                    else cat.ParentID = 0;
                    isOk = Service.CategoriesService.Add(cat, errors);
                }
                //修改
                else if (mode == "edit")
                {
                    if (string.IsNullOrEmpty(req.Form["CatID"]) || !int.TryParse(req.Form["CatID"], out cid) || cid <= 0) errors.Add("categoryid_null");
                    if (!string.IsNullOrEmpty(req.Form["Name"]) && !Regex.IsMatch(req.Form["Name"], Validater.OtherName)) errors.Add("name_format");
                    CategoriesModel cat = Service.CategoriesService.One(cid);
                    if (cat == null) errors.Add("category_null");
                    else
                    {
                        cat.ID = cid;
                        cat.Title = string.IsNullOrEmpty(req.Form["Title"]) ? cat.Title : req.Form["Title"].Trim();
                        cat.Name = string.IsNullOrEmpty(req.Form["Name"]) ? string.Empty : req.Form["Name"].Trim();
                        cat.ThemeGuid = string.IsNullOrEmpty(req.Form["Template"]) ? cat.ThemeGuid : req.Form["Template"].Trim();
                        cat.Des = string.IsNullOrEmpty(req.Form["Des"]) ? "" : req.Form["Des"].Trim();
                        if (!string.IsNullOrEmpty(req.Form["Parent"]) && int.TryParse(req.Form["Parent"].Trim(), out cid)) cat.ParentID = cid;
                        else cat.ParentID = 0;
                        isOk = Service.CategoriesService.Update(cat, errors);
                    }
                }
                //快速编辑
                else if (mode == "quick")
                {
                    if (string.IsNullOrEmpty(req.Form["CatID"]) || !int.TryParse(req.Form["CatID"], out cid) || cid <= 0) errors.Add("categoryid_null");
                    if (!string.IsNullOrEmpty(req.Form["Name"]) && !Regex.IsMatch(req.Form["Name"], Validater.OtherName)) errors.Add("name_format");
                    CategoriesModel cat = Service.CategoriesService.One(cid);
                    if (cat == null) errors.Add("category_null");
                    else
                    {
                        cat.ID = cid;
                        cat.Title = string.IsNullOrEmpty(req.Form["Title"]) ? cat.Title : req.Form["Title"].Trim();
                        cat.Name = string.IsNullOrEmpty(req.Form["Name"]) ? string.Empty : req.Form["Name"].Trim();
                        isOk = Service.CategoriesService.Update(cat, errors);
                    }
                }
                //删除
                else if (mode == "delete")
                {
                    if (string.IsNullOrEmpty(req.Form["CatID"]) || !int.TryParse(req.Form["CatID"], out cid) || cid <= 0) errors.Add("categoryid_null");
                    else
                    {
                        isOk = Service.CategoriesService.Delete(cid, false);
                        if (!isOk) errors.Add("on_delete_error");
                    }
                }
                context.Response.Write(JsonConvert.SerializeObject(isOk ? (object)new { result = "ok" } : new { result = "no", errors = errors }));
                return;
            }
            base.ProcessRequest(context);
        }
    }
}