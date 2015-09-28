using BulaqCMS.Common;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class link_editor : AdminBasePage
    {
        /// <summary>
        /// 所有连接
        /// </summary>
        protected List<LinksModel> allLinks;

        /// <summary>
        /// 连接分组
        /// </summary>
        protected List<string> linkGroups;

        /// <summary>
        /// 要修改的连接
        /// </summary>
        protected LinksModel UpdateLinks;

        /// <summary>
        /// 是否新增状态
        /// </summary>
        protected bool isEdit = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            allLinks = Service.LinksService.GetList();
            linkGroups = allLinks.Select(p => p.Name).Where(p => !stringNull(p.Trim())).Distinct().ToList();
            string mode = stringNull(Request["mode"]) ? "new" : Request["mode"].Trim().ToLower();
            if (mode != "new" && mode != "edit") mode = "new";
            if (mode == "edit")
            {
                int linkId = 0;
                if (!stringNull(Request["linkid"]) && int.TryParse(Request["linkid"].Trim(), out linkId))
                {
                    UpdateLinks = allLinks.FirstOrDefault(p => p.ID == linkId);
                    if (UpdateLinks != null) isEdit = true;
                }
            }
        }

        public override string ActivePage
        {
            get
            {
                return "link-editor";
            }
        }

        protected override void OnInit(EventArgs e)
        {
            if (Method == HttpMethod.HttpPost)
            {
                var frm = _Context.Request.Form;
                string[] modes = { "new", "edit", "linkgroup_add", "linkgroup", "target", "visible", "delete" };
                var mode = frm["mode"];
                if (!stringNull(mode) && modes.Contains(mode.ToLower().Trim()))
                {
                    mode = mode.ToLower().Trim();
                    string error = null;
                    bool isOk = false;
                    object res = null;
                    if (mode == "new")
                    {
                        if (stringNull(frm["title"])) error = "title_null";
                        else if (stringNull(frm["Url"])) error = "url_null";
                        else if (!Regex.IsMatch(frm["Url"].Trim(), Validater.LinkUrl, RegexOptions.IgnoreCase)) error = "url_format";
                        else
                        {
                            LinksModel link = new LinksModel()
                            {
                                Des = stringNull(frm["Des"]) ? "" : frm["Des"].Trim(),
                                Name = "",
                                Image = "",
                                Index = 0,
                                Title = frm["Title"].Trim(),
                                Target = 1,
                                Url = frm["Url"].Trim(),
                                Visible = true
                            };
                            //添加
                            if (Service.LinksService.Add(link)) isOk = true;
                            else error = "on_add_link_error";
                        }
                    }
                    else if (mode == "edit")
                    {
                        //修改
                        int lid = 0;
                        if (stringNull(frm["LinkID"]) || !int.TryParse(frm["LinkID"].Trim(), out lid) || lid <= 0) error = "link_null";
                        else if (stringNull(frm["title"])) error = "title_null";
                        else if (stringNull(frm["Url"])) error = "url_null";
                        else if (!Regex.IsMatch(frm["Url"].Trim(), Validater.LinkUrl, RegexOptions.IgnoreCase)) error = "url_format";
                        else
                        {
                            var link = Service.LinksService.GetList().FirstOrDefault(p => p.ID == lid);
                            if (link == null) error = "link_null";
                            else
                            {
                                link.Title = frm["Title"].Trim();
                                link.Url = frm["Url"].Trim();
                                link.Des = stringNull(frm["Des"]) ? "" : frm["Des"].Trim();
                                if (Service.LinksService.Update(link)) isOk = true;
                                else error = "on_update_link_error";
                            }
                        }
                    }
                    else if (mode == "linkgroup_add")
                    {
                        //添加分类
                        int lid = 0;
                        if (stringNull(frm["LinkID"]) || !int.TryParse(frm["LinkID"].Trim(), out lid) || lid <= 0) error = "link_null";
                        else if (stringNull(frm["GroupName"])) error = "group_null";
                        else
                        {
                            var link = Service.LinksService.GetList().FirstOrDefault(p => p.ID == lid);
                            if (link == null) error = "link_null";
                            else
                            {
                                link.Name = frm["GroupName"].Trim();
                                if (Service.LinksService.Update(link))
                                {
                                    isOk = true;
                                    //获取所有的分组
                                    var groups = Service.LinksService.GetList().Select(p => p.Name).Where(p => !stringNull(p)).Distinct();
                                    var group = link.Name;
                                    res = new { group = group, groups = groups };
                                    Links.linkInGuids = null;
                                }
                                else error = "on_group_name_error";
                            }
                        }
                    }
                    else if (mode == "linkgroup")
                    {
                        //添加分类
                        int lid = 0;
                        if (stringNull(frm["LinkID"]) || !int.TryParse(frm["LinkID"].Trim(), out lid) || lid <= 0) error = "link_null";
                        else
                        {
                            var link = Service.LinksService.GetList().FirstOrDefault(p => p.ID == lid);
                            if (link == null) error = "link_null";
                            else
                            {
                                link.Name = stringNull(frm["LinkGroups"]) ? "" : frm["LinkGroups"].Trim();
                                if (Service.LinksService.Update(link)) isOk = true;
                                else error = "on_group_name_error";
                            }
                        }
                    }
                    else if (mode == "target")
                    {
                        //修改
                        int lid = 0;
                        if (stringNull(frm["LinkID"]) || !int.TryParse(frm["LinkID"].Trim(), out lid) || lid <= 0) error = "link_null";
                        else
                        {
                            var link = Service.LinksService.GetList().FirstOrDefault(p => p.ID == lid);
                            if (link == null) error = "link_null";
                            else
                            {
                                short tar = 1;
                                link.Target = !stringNull(frm["Target"]) && short.TryParse(frm["Target"].Trim(), out tar) && tar > 0 && tar <= 5 ? tar : link.Target;
                                if (Service.LinksService.Update(link)) isOk = true;
                                else error = "on_target_error";
                            }
                        }
                    }
                    else if (mode == "visible")
                    {
                        int lid = 0;
                        if (stringNull(frm["LinkID"]) || !int.TryParse(frm["LinkID"].Trim(), out lid) || lid <= 0) error = "link_null";
                        else
                        {
                            var link = Service.LinksService.GetList().FirstOrDefault(p => p.ID == lid);
                            if (link == null) error = "link_null";
                            else
                            {
                                bool vis = false;
                                link.Visible = !stringNull(frm["Visible"]) && bool.TryParse(frm["Visible"].Trim(), out vis) ? vis : link.Visible;
                                if (Service.LinksService.Update(link)) isOk = true;
                                else error = "on_visible_error";
                            }
                        }
                    }
                    else if (mode == "delete")
                    {
                        //删除
                        int lid = 0;
                        if (stringNull(frm["LinkID"]) || !int.TryParse(frm["LinkID"].Trim(), out lid) || lid <= 0) error = "link_null";
                        else
                        {
                            var link = Service.LinksService.GetList().FirstOrDefault(p => p.ID == lid);
                            if (link == null) error = "link_null";
                            else
                            {
                               
                                if (Service.LinksService.Delete(link)) isOk = true;
                                else error = "on_delete_error";
                            }
                        }
                    }
                    Result.SetResult(isOk).SetError(error).SetRes(res);
                }
            }
            base.OnInit(e);
        }
    }
}