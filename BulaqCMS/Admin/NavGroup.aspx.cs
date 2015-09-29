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
    public partial class NavGroup : AdminBasePage
    {

        /// <summary>
        /// 所有分类
        /// </summary>
        protected List<NavGroupModel> allGroups;

        /// <summary>
        /// 当前编辑状态下的菜单分类
        /// </summary>
        protected NavGroupModel updateGroup;

        /// <summary>
        /// 编辑状态
        /// </summary>
        protected bool isEdit;

        protected void Page_Load(object sender, EventArgs e)
        {
            allGroups = Service.NavGroupService.GetList(true);
            if (!stringNull(Request.QueryString["mode"]))
            {
                string mode = Request.QueryString["mode"].Trim().ToLower();
                mode = mode == "new" || mode == "edit" ? mode : "new";
                if (mode == "edit" && !stringNull(Request.QueryString["navgroup"]))
                {
                    string gname = Request.QueryString["navgroup"].Trim();
                    updateGroup = allGroups.FirstOrDefault(p => p.Name.ToLower() == gname.ToLower());
                    if (updateGroup != null) isEdit = true;
                }
            }
            if (!isEdit) updateGroup = new NavGroupModel();
        }

        public override string ActivePage
        {
            get
            {
                return "nav_groups";
            }
        }

        protected override void OnInit(EventArgs e)
        {
            if (Method == HttpMethod.HttpPost && ResponseType == ResponseDataType.Json)
            {
                var frm = _Context.Request.Form;
                string mode = stringNull(frm["Mode"]) ? null : frm["Mode"].Trim().ToLower();
                string[] modes = { "new", "edit", "delete" };
                if (modes.Contains(mode))
                {
                    string error = null;
                    bool isOk = false;
                    object res = null;
                    allGroups = Service.NavGroupService.GetList();
                    if (mode == "edit")
                    {
                        int groupId = 0;
                        if (stringNull(frm["NavGroupID"]) || !int.TryParse(frm["NavGroupID"].Trim(), out groupId) || groupId <= 0) error = "group_null";
                        else
                        {
                            var group = allGroups.FirstOrDefault(p => p.ID == groupId);
                            if (group == null) error = "group_null";
                            else
                            {
                                string name = frm["Name"];
                                if (stringNull(name)) error = "name_null";
                                else if (!Regex.IsMatch(name.Trim(), Validater.OtherName)) error = "name_format";
                                else if (allGroups.Count(p => p.Name.ToLower() == name.Trim().ToLower() && p.ID != group.ID) > 0) error = "has_name";
                                else
                                {
                                    string title = frm["Title"];
                                    if (stringNull(frm["Title"])) error = "title_null";
                                    else
                                    {
                                        group.Name = name.Trim();
                                        group.Title = title.Trim();
                                        group.Des = stringNull(frm["Des"]) ? group.Des : frm["Des"].Trim();
                                        if (Service.NavGroupService.Update(group)) isOk = true;
                                        else error = "on_edit_error";
                                    }
                                }
                            }
                        }
                    }
                    else if (mode == "new")
                    {
                        //新增
                        string name = frm["Name"];
                        if (!stringNull(name) && !Regex.IsMatch(name.Trim(), Validater.OtherName)) error = "name_format";
                        else if (!stringNull(name) && allGroups.Count(p => p.Name.ToLower() == name.Trim().ToLower()) > 0) error = "has_name";
                        else
                        {
                            name = stringNull(name) ? Guid.NewGuid().ToString().Replace("-", "") : name.Trim();
                            string title = frm["Title"];
                            if (stringNull(frm["Title"])) error = "title_null";
                            else
                            {
                                NavGroupModel group = new NavGroupModel()
                                {
                                    Name = name,
                                    Title = title.Trim(),
                                    Des = stringNull(frm["Des"]) ? "" : frm["Des"].Trim(),
                                };
                                if (Service.NavGroupService.Add(group)) isOk = true;
                                else error = "on_add_error";
                            }
                        }
                    }
                    else if (mode == "delete")
                    {
                        int groupId = 0;
                        if (stringNull(frm["NavGroupID"]) || !int.TryParse(frm["NavGroupID"].Trim(), out groupId) || groupId <= 0) error = "group_null";
                        else
                        {
                            var group = allGroups.FirstOrDefault(p => p.ID == groupId);
                            if (group == null) error = "group_null";
                            else
                            {
                                //删除
                                if (Service.NavGroupService.Delete(group.ID)) isOk = true;
                                else error = "on_delete_error";
                            }
                        }
                    }
                    Result.Set(isOk, error, res);
                }
            }
            base.OnInit(e);
        }
    }
}