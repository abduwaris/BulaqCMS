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
    public partial class Tags : AdminBasePage
    {
        protected bool isEdit = false;

        protected TagsModel updateTag;

        protected List<TagsModel> allTags;
        protected void Page_Load(object sender, EventArgs e)
        {
            allTags = Service.TagsService.GetList(true);
            int tagId;
            if (!string.IsNullOrEmpty(Request.QueryString["tagid"]) && int.TryParse(Request.QueryString["tagid"].Trim(), out tagId))
            {
                updateTag = allTags.FirstOrDefault(p => p.ID == tagId);
                isEdit = updateTag != null;
            }
            updateTag = updateTag ?? new TagsModel();
        }
        public override string ActivePage
        {
            get
            {
                return "post-tags";
            }
        }

        public override void ProcessRequest(HttpContext context)
        {
            if (Method == HttpMethod.HttpPost && IsOnline)
            {
                var frm = this._Context.Request.Form;
                List<string> errors = new List<string>();
                bool isOk = false;
                object res = null;
                string mode = string.IsNullOrEmpty(frm["Mode"]) ? null : frm["Mode"].ToLower().Trim();
                if (mode == "new" || mode == "edit" || mode == "frompostpage")
                {
                    TagsModel tag = null;
                    string title = string.IsNullOrEmpty(frm["Title"]) ? null : frm["Title"].Trim();
                    string name = string.IsNullOrEmpty(frm["Name"]) ? null : frm["Name"].Trim();
                    if (name != null && !Regex.IsMatch(name, Validater.OtherName)) errors.Add("name_format");
                    string des = string.IsNullOrEmpty(frm["Des"]) ? null : frm["Des"].Trim();
                    if (mode == "frompostpage")
                    {
                        //标签从文章发表页面提交
                        tag = new TagsModel() { Des = "", Name = Guid.NewGuid().ToString().Replace("-", "") };
                        if (title == null) errors.Add("title_null");
                        else tag.Title = title;
                        if (errors.Count <= 0) isOk = Service.TagsService.QuickAdd(tag);
                    }
                    else if (mode == "edit")
                    {
                        //修改
                        int tagId = 0;
                        if (!string.IsNullOrEmpty(frm["TagID"]) && int.TryParse(frm["TagID"].Trim(), out tagId))
                        {
                            tag = Service.TagsService.GetTags(tagId);
                            if (tag == null) errors.Add("tag_null");
                            else
                            {
                                tag.Title = title ?? tag.Title;
                                tag.Name = name ?? tag.Name;
                                tag.Des = des ?? tag.Des;
                            }
                            if (title == null && name == null && des == null) isOk = true;
                            else isOk = Service.TagsService.Update(tag, errors);
                        }
                        else errors.Add("tagid_null");
                    }
                    else
                    {
                        //新增
                        tag = new TagsModel();
                        if (title == null) errors.Add("title_null");
                        else tag.Title = title;
                        tag.Name = name ?? Guid.NewGuid().ToString().Replace("-", "");
                        tag.Des = des ?? "";
                        if (errors.Count <= 0) isOk = Service.TagsService.Add(tag, errors);
                    }
                    if (isOk) res = new { tag_id = tag.ID, tag_title = tag.Title, tag_name = tag.Name };
                    errors = errors.Count > 0 ? errors : null;
                    context.Response.Write(JsonConvert.SerializeObject(new { result = isOk ? "ok" : "no", errors = errors, res = res }, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));
                    return;
                }
            }
            base.ProcessRequest(context);
        }
    }
}
