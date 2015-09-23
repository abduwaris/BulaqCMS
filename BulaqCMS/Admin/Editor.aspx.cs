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
    public partial class Editor : AdminBasePage
    {
        /// <summary>
        /// 所有的专辑
        /// </summary>
        protected List<CategoriesModel> Cats;

        /// <summary>
        /// 要修改的文章
        /// </summary>
        protected PostsModel UpdatePosts = null;

        ///// <summary>
        ///// 当前修改文章的标签
        ///// </summary>
        //protected List<PostInTagsModel> pinTags;

        /// <summary>
        /// 当前修改的文章的标签
        /// </summary>
        protected List<TagsModel> postTags = new List<TagsModel>();

        /// <summary>
        /// 文章专辑关系
        /// </summary>
        protected List<PostInCategoriesModel> PostInCats;

        protected bool isEdit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //输出所有的专辑
            var mode = string.IsNullOrEmpty(Request.QueryString["mode"]) ? "new" : Request.QueryString["mode"].Trim().ToLower();
            if (mode != "new" && mode != "edit") mode = "new";
            if (mode == "edit")
            {
                int pid = 0;
                if (int.TryParse(Request.QueryString["pid"].Trim(), out pid) && pid > 0)
                {
                    UpdatePosts = Service.PostsService.GetPostById(pid);
                    if (UpdatePosts == null) Response.Redirect("Editor.aspx?mode=new");
                    PostInCats = Service.PostInCategoriesService.GetList(pid, true);
                    //获取标签
                    postTags.AddRange(Service.TagsService.GetTagsByPostId(pid));
                    isEdit = true;
                }
            }
            Cats = Service.CategoriesService.GetList();
        }

        public override string ActivePage
        {
            get
            {
                return "post-editor";
            }
        }

        public override void ProcessRequest(HttpContext context)
        {
            //判断是否 Post 过来的
            if (IsOnline)
            {
                if (Method == HttpMethod.HttpPost)
                {
                    var frm = context.Request.Form;
                    string mode = string.IsNullOrEmpty(frm["Mode"]) ? "" : frm["mode"].Trim();
                    /// new 新增文章
                    /// update 整体保存
                    /// savePractice 保存成草稿
                    /// send 发布
                    /// toRecycle   放入回收站
                    /// delFlag  删除表示
                    /// delete   彻底删除
                    /// cats        专辑修改
                    /// newTag      新增标签
                    /// delTag  删除标签
                    /// pic     图片设置
                    /// aprove  批准
                    List<string> errors = new List<string>();
                    bool isOk = false;
                    string[] modes = { "new", "save", "savepractice", "send",  "delflag", "delete", "cats", "newtag", "deltag", "pic", "aprove" };
                    if (modes.Contains(mode))
                    {
                        //返回类型
                        object retains = null;

                        #region Add
                        if (mode == "new")
                        {
                            //新增
                            if (string.IsNullOrEmpty(frm["Title"])) errors.Add("title_null");
                            else
                            {
                                PostsModel po = new PostsModel()
                                {
                                    Title = frm["Title"].Trim(),
                                    Approved = false,
                                    AuthorID = OnlineUser.ID,
                                    CanComment = true,
                                    Content = string.IsNullOrEmpty(frm["Content"]) ? "" : frm["Content"],
                                    CreateTime = DateTime.Now,
                                    DelFlag = false,
                                    IP = context.Request.UserHostAddress,
                                    //LastModifiedTime = DateTime.Now,
                                    Modified = false,
                                    Name = Guid.NewGuid().ToString().Replace("-", ""),
                                    Password = "",
                                    PasswordState = false,
                                    PostImage = "",
                                    PostType = false,
                                    Practice = false,
                                    // SendTime = DateTime.Now,
                                    ThemeGuid = "",
                                    UserAgent = context.Request.UserAgent,
                                    VisibleState = 1
                                };
                                //新增
                                isOk = Service.PostsService.Add(po);
                                if (isOk)
                                {
                                    po = Service.PostsService.GetPostByName(po.Name);
                                    retains = new { post_id = po.ID, post_name = po.Name };
                                }
                                else errors.Add("on_new_error");
                            }
                        }
                        #endregion
                        else
                        {
                            int postId = 0;
                            if (string.IsNullOrEmpty(frm["PostID"]) || !int.TryParse(frm["PostID"], out postId)) errors.Add("post_null");
                            PostsModel pos = Service.PostsService.GetPostById(postId);
                            if (pos == null) errors.Add("post_null");
                            if (errors.Count <= 0)
                            {
                                #region Save
                                if (mode == "save")
                                {
                                    if (string.IsNullOrEmpty(frm["Title"])) errors.Add("title_null");
                                    if (!string.IsNullOrEmpty(frm["Name"]) && !Regex.IsMatch(frm["name"].Trim(), Validater.OtherName)) errors.Add("name_format");
                                    if (errors.Count <= 0)
                                    {
                                        pos.ID = postId;
                                        pos.Name = string.IsNullOrEmpty(frm["Name"]) ? pos.Name : frm["Name"].Trim();
                                        pos.Title = frm["Title"].Length > 250 ? frm["Title"].Trim().Substring(0, 250) : frm["Title"].Trim();
                                        pos.Content = string.IsNullOrEmpty(frm["Content"]) ? pos.Content : frm["Content"];
                                        if (!pos.Practice)
                                        {
                                            pos.Modified = true;
                                            pos.LastModifiedTime = DateTime.Now;
                                        }
                                        //修改可以完善
                                        isOk = Service.PostsService.Update(pos);
                                        if (!isOk) errors.Add("on_save_error");
                                    }
                                }
                                #endregion

                                #region savePractice Or Send
                                else if (mode == "savepractice" || mode == "send")
                                {
                                    if (mode == "send" && pos.SendTime == null) pos.SendTime = DateTime.Now;
                                    pos.Practice = mode == "savepractice";
                                    isOk = Service.PostsService.Update(pos);
                                    if (!isOk) errors.Add("on_practice_error");
                                }
                                #endregion

                                #region Recycle DelFlag
                                else if (mode == "delflag" || mode == "aprove")
                                {
                                    bool b = false;
                                    if (!string.IsNullOrEmpty(frm["val"]) && bool.TryParse(frm["val"], out b))
                                    {
                                        if (mode == "aprove") pos.Approved = b;
                                        else pos.DelFlag = b;
                                        isOk = Service.PostsService.Update(pos);
                                    }
                                    if (!isOk) errors.Add(string.Format("on_{0}_error", mode == "aprove" ? "aprove" : "del"));
                                }
                                #endregion

                                #region Delete
                                //彻底删除
                                else if (mode == "delete")
                                {
                                    isOk = Service.PostsService.Delete(postId);
                                    if (!isOk) errors.Add("on_delete_error");
                                }

                                #endregion

                                #region Pic 图片
                                else if (mode == "pic")
                                {
                                    pos.PostImage = string.IsNullOrEmpty(frm["Pic"]) ? "" : frm["Pic"];
                                    isOk = Service.PostsService.Update(pos);
                                    if (!isOk) errors.Add("on_editpic_error");
                                }
                                #endregion

                                #region Categories Edit

                                if (mode == "cats")
                                {
                                    //当前编辑状态下的文章的已设置的专辑集合
                                    var postInCats = Service.PostInCategoriesService.GetList(postId, true);
                                    //当前要设置的
                                    string[] newPostInCats = frm.GetValues("Cats");
                                    if (newPostInCats == null) newPostInCats = new string[] { };
                                    //判断当前已设置专辑中用没有删除的
                                    if (postInCats.Count(p => !newPostInCats.Contains(p.ToString())) > 0)
                                    {
                                        //删除
                                        var willDelIds = postInCats.Where(p => !newPostInCats.Contains(p.ToString())).Select(p => p.ID);
                                        Service.PostInCategoriesService.Delete(willDelIds.ToArray());
                                        postInCats = Service.PostInCategoriesService.GetList(postId, true);
                                    }
                                    //获取要新增的
                                    int ppid = 0;
                                    var willAdd = newPostInCats.Where(p => int.TryParse(p, out ppid) && postInCats.Count(u => u.ID.ToString() == p) <= 0).Select(p => int.Parse(p));
                                    if (willAdd.Count() > 0)
                                    {
                                        //新增
                                        Service.PostInCategoriesService.AddForPost(postId, willAdd.ToArray());
                                    }
                                    isOk = true;
                                    retains = Service.PostInCategoriesService.GetList(postId, true).Select(p => p.CategoryID);
                                }
                                #endregion

                                #region 提交标签

                                #endregion

                                #region 删除标签

                                #endregion
                            }
                        }
                        context.Response.Write(JsonConvert.SerializeObject(new { result = isOk ? "ok" : "no", errors = errors, res = retains }));
                        return;
                    }
                }
            }
            base.ProcessRequest(context);
        }

        /// <summary>
        /// 让文章新增提交的标签
        /// <param name="postId">文章ID</param>
        /// <param name="errors">错误信息</param>
        /// <param name="tags">新增之后的</param>
        /// </summary>
        bool AddTags(int postId, List<string> errors, List<TagsModel> tags)
        {
            var frm = _Context.Request.Form;
            string tagsStr = frm["TagTitles"];
            if (string.IsNullOrEmpty(tagsStr))
            {
                errors.Add("titles_null");
                return false;
            }
            //
            string[] tagList = tagsStr.Split(new char[] { ',', '،' }, StringSplitOptions.RemoveEmptyEntries);
            if (tagList.Length <= 0)
            {
                errors.Add("titles_null");
                return false;
            }
            foreach (var tg in tagList)
            {
                var newTag = new TagsModel() { Title = tg.Trim() };
                bool bok = Service.TagsService.QuickAdd(newTag);
                if (bok) tags.Add(newTag);
            }
            //添加到关系数据库

            return true;
        }
    }
}