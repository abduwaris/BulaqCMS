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

        protected override void OnInitComplete(EventArgs e)
        {
            //base.OnInitComplete(e);
        }

        protected override void OnInit(EventArgs e)
        {
            if (Method == HttpMethod.HttpPost && IsOnline)
            {
                var frm = this._Context.Request.Form;
                string mode = string.IsNullOrEmpty(frm["Mode"]) ? null : frm["Mode"].ToLower().Trim();
                string[] modes = { "new", "edit", "frompostpage", "delete" };
                if (modes.Contains(mode))
                {
                    string error = null;
                    bool isOk = false;
                    object res = null;
                    TagsModel tag = null;
                    var insertedTags = Service.TagsService.GetList();
                    string title = string.IsNullOrEmpty(frm["Title"]) ? null : frm["Title"].Trim();
                    string name = string.IsNullOrEmpty(frm["Name"]) ? null : frm["Name"].Trim();
                    //if (name != null && !Regex.IsMatch(name, Validater.OtherName)) error = "name_format";
                    string des = string.IsNullOrEmpty(frm["Des"]) ? null : frm["Des"].Trim();
                    if (mode == "new")
                    {
                        if (title == null) error = "title_null";
                        else if (!stringNull(name))
                        {
                            //判断是否存在
                            if (insertedTags.Count(p => p.Name.ToLower() == name.ToLower()) > 0) error = "has_name";
                            else if (!Regex.IsMatch(name, Validater.OtherName)) error = "name_format";
                        }
                        if (stringNull(error))
                        {
                            tag = new TagsModel();
                            tag.Title = title;
                            if (stringNull(name))
                            {
                            newTagName:
                                name = Guid.NewGuid().ToString().ToLower().Replace("-", "");
                                if (insertedTags.Count(p => p.Name.ToLower() == name) > 0)
                                    goto newTagName;
                            }
                            tag.Name = name;
                            tag.Des = stringNull(des) ? "" : des;
                            //添加
                            if (Service.TagsService.Add(tag))
                            {
                                isOk = true;
                                //insertedTags = Service.TagsService.GetList();
                                //res = insertedTags.First(p => p.Name == name);
                            }
                            else error = "on-add-error";
                        }
                    }
                    else if (mode == "edit")
                    {
                        int tagId = 0;
                        if (stringNull(frm["TagID"]) || !int.TryParse(frm["TagID"].Trim(), out tagId) || insertedTags.Count(p => p.ID == tagId) <= 0)
                            error = "tag_null";
                        else if (stringNull(title)) error = "title_null";
                        else
                        {
                            if (!stringNull(name))
                            {
                                //判断是否存在
                                if (insertedTags.Count(p => p.Name.ToLower() == name.ToLower()) > 0) error = "has_name";
                                else if (!Regex.IsMatch(name, Validater.OtherName)) error = "name_format";
                            }
                            if (stringNull(error))
                            {
                                tag = insertedTags.First(p => p.ID == tagId);
                                tag.Title = title;
                                tag.Name = stringNull(name) ? tag.Name : name;
                                tag.Des = stringNull(des) ? tag.Des : des;
                                //掺入
                                if (Service.TagsService.Update(tag))
                                {
                                    isOk = true;
                                    //res = Service.TagsService.GetTags(tagId);
                                }
                                else error = "on-update-error";
                            }
                        }
                    }
                    else if (mode == "frompostpage")
                    {
                        //标签从文章发表页面提交,快速添加
                        int postId = 0;
                        if (stringNull(title)) error = "title_null";
                        else if (stringNull(frm["PostID"]) || !int.TryParse(frm["PostID"].Trim(), out postId) || Service.PostsService.GetPostById(postId) == null) error = "post_null";
                        else
                        {
                            //分割
                            string[] titles = title.Split(new char[] { ',', '،' }, StringSplitOptions.RemoveEmptyEntries);
                            if (titles.Length <= 0) error = "title_null";
                            else
                            {
                                //循环判断添加
                                foreach (var tit in titles)
                                {
                                    //判断是否存在
                                    if (insertedTags.Count(p => p.Title == tit) > 0) continue;

                                    tag = new TagsModel() { Des = "", Title = tit.Trim() };
                                newTagName:
                                    name = Guid.NewGuid().ToString().ToLower().Replace("-", "");
                                    if (insertedTags.Count(p => p.Name.ToLower() == name) > 0)
                                        goto newTagName;
                                    tag.Name = name;
                                    Service.TagsService.Add(tag);
                                }
                                insertedTags = Service.TagsService.GetList();
                                var newTags = insertedTags.Where(p => titles.Count(s => s.Trim() == p.Title) > 0);
                                if (newTags.Count() > 0)
                                {
                                    //isOk = true;
                                    //res = newTags.Select(p => new { tag_id = p.ID, tag_name = p.Name });
                                    //添加关系
                                    //获取没有添加的
                                    var postInTags = Service.PostInTagsService.GetListByPost(postId);
                                    var allPostInTags = newTags.Select(p => new PostInTagsModel() { PostID = postId, TagID = p.ID });
                                    var canInsertPostinTags = allPostInTags.Where(p => !newTags.Select(u => u.ID).Contains(p.TagID));
                                    if (canInsertPostinTags.Count() > 0)
                                    {
                                        //批量添加关系
                                        Service.PostInTagsService.Add(canInsertPostinTags.ToList());
                                        postInTags = Service.PostInTagsService.GetListByPost(postId);
                                    }
                                    //获取
                                    newTags = newTags.Where(p => postInTags.Select(u => u.TagID).Contains(p.ID));
                                    res = newTags;
                                }
                                else error = "on_quickadd_error";
                            }
                        }
                    }
                    else if (mode == "delete")
                    {
                        //删除
                        int tagId = 0;
                        if (stringNull(frm["TagID"]) || !int.TryParse(frm["TagID"].Trim(), out tagId) || Service.TagsService.GetTags(tagId) == null)
                            error = "tag_null";
                        else
                        {
                            if (Service.TagsService.Delete(tagId)) isOk = true;
                            else error = "on_delete_error";
                        }
                    }
                    //设置返回参数
                    Result.SetResult(isOk).SetError(error).SetRes(res);
                }
            }
            base.OnInit(e);
        }
    }
}
