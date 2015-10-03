using BulaqCMS.Common;
using BulaqCMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class Editor : AdminBasePage
    {
        /// 路由
        /// /Blog  所有博客
        /// /Blog/{[\d+]}/  页码博客
        /// /Blog/Categories/{categoryName}
        /// /Blog/{blogName}/
        /// /Blog/{blogName}/
        /// 
        /// /Posts  所有博客
        /// /Posts/{pageIndex[\d+]} 摸个页内的博客
        /// /Posts/{postName}/ 页面
        /// /Categories/{catName}/{pageIndex[\d+]} 摸个专辑页码
        ///         /Categories  所有专辑
        ///         /Categories/{pageIndex[\d+]}/ 所有专辑页码
        ///         /Categories/{catName} 专辑名称
        /// /{PagesPrev[not Posts,not Categories]}/{pageName}
        ///         如果没有也前缀, 则把路由排在最前,特殊字符不能做也名称
        ///             [
        ///                 Post,
        ///                 Posts,
        ///                 Blogs,
        ///                 Blog,
        ///                 Categories,
        ///                 Category,
        ///                 Pages,
        ///                 Page,
        ///                 Tags,
        ///                 Tag,
        ///                 Search,
        ///                 S
        ///             /About/
        /// /Tags/{tagName}/{pageIndex}
        ///          /Tags/  所有标签
        ///          /Tags/{pageIndex[\d+]} 所有标签, 摸个页面
        /// /Search/{keyWords} 搜索



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
                if (int.TryParse(Request.QueryString["postid"].Trim(), out pid) && pid > 0)
                {
                    UpdatePosts = Service.PostsService.GetPostById(pid);
                    if (UpdatePosts == null) Response.Redirect("Editor.aspx?mode=new");
                    PostInCats = Service.PostInCategoriesService.GetList(pid, true);
                    //获取标签
                    postTags = Service.TagsService.GetTagsByPostId(UpdatePosts.ID); //postTags.AddRange(Service.TagsService.GetTagsByPostId(pid));
                    isEdit = true;
                }
            }
            PostInCats = PostInCats ?? new List<PostInCategoriesModel>();
            Cats = Service.CategoriesService.GetList();
        }

        public override string ActivePage
        {
            get
            {
                return "post-editor";
            }
        }

        /// <summary>
        /// 错误
        /// </summary>
        private string error = null;

        /// <summary>
        /// 是否成功
        /// </summary>
        private bool isOk = false;

        /// <summary>
        /// 额外参数
        /// </summary>
        private object res = null;

        private NameValueCollection Frm;

        protected override void OnInit(EventArgs e)
        {
            if (Method == HttpMethod.HttpPost && ResponseType == ResponseDataType.Json)
            {
                Frm = _Context.Request.Form;
                string mode = string.IsNullOrEmpty(Frm["Mode"]) ? string.Empty : Frm["mode"].Trim();
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
                //bool isOk = false;
                string[] modes = { "new", "edit", "rename", "savepractice", "send", "delflag", "delete", "cats", "newtag", "deltag", "pic", "aprove" };
                if (modes.Contains(mode))
                {
                    string title = stringNull(Frm["Title"]) ? null : Frm["Title"].Trim();
                    string name = stringNull(Frm["Name"]) ? null : Frm["Name"].Trim();
                    string content = stringNull(Frm["Content"]) ? null : Frm["Content"].Trim();
                    bool approved = false;
                    bool _approvedSet = !stringNull(Frm["Approved"]) && bool.TryParse(Frm["Approved"].Trim(), out approved);
                    bool practice = true;
                    bool _practiceSet = !stringNull(Frm["Practice"]) && bool.TryParse(Frm["Practice"].Trim(), out practice);
                    short visible = !stringNull(Frm["Visible"]) && short.TryParse(Frm["Visible"].Trim(), out visible) ? (visible < (short)1 || visible > (short)4 ? (short)1 : visible) : (short)1;
                    string[] categories = Frm.GetValues("Categories");
                    string[] tags = Frm.GetValues("Tags");
                    if (tags != null && tags.Length > 0)
                    {
                        var tagList = tags.ToList();
                        tagList.ForEach(p => p.Trim());
                        tags = tagList.Distinct().ToArray();
                    }
                    string image = stringNull(Frm["Image"]) ? null : Frm["Image"].Trim();
                    int postId = 0;
                    bool _postId_set = !stringNull(Frm["PostID"]) && int.TryParse(Frm["PostID"].Trim(), out postId);

                    //返回类型
                    #region Add
                    if (mode == "new")
                    {
                        //新增
                        if (title != string.Empty)
                        {
                            PostsModel post = new PostsModel()
                            {
                                Title = title,
                                Content = content ?? "",
                                Approved = _approvedSet && approved,
                                AuthorID = OnlineUser.ID,
                                CanComment = true,
                                CreateTime = DateTime.Now,
                                DelFlag = false,
                                IP = _Context.Request.UserHostAddress,
                                Modified = false,
                                LastModifiedTime = DateTime.Now,
                                Name = Guid.NewGuid().ToString().Replace("-", ""),
                                NeadPassword = false,
                                Password = "",
                                SendTime = DateTime.Now,
                                Practice = _practiceSet ? _practiceSet && practice : true,
                                PostImage = image ?? "",
                                ThemeGuid = "",
                                UserAgent = _Context.Request.UserAgent,
                                VisibleState = visible,
                                PostType = false,
                            };

                            if (Service.PostsService.Add(post))
                            {
                                post = Service.PostsService.GetPostByName(post.Name);
                                //标签
                                AddTags(post.ID, tags, true);
                                post.Tags = tags != null && tags.Length > 0 ? Service.TagsService.GetTagsByPostId(post.ID) : new List<TagsModel>();

                                //插入分类
                                AddCategories(post.ID, categories, true);
                                post.Categories = Service.CategoriesService.CategoriesByPost(post.ID);

                                //设置结果
                                res = new { post_id = post.ID, post_name = post.Name, tags = post.Tags.Select(p => p.Title), cats = post.Categories.Select(p => p.ID) };
                                isOk = true;
                            }
                            else error = "on_new_error";
                        }
                        else error = "title_null";

                    }

                    #endregion

                    #region Edit

                    else if (mode == "edit")
                    {
                        if (postId > 0)
                        {
                            var post = Service.PostsService.GetPostById(postId);
                            if (post != null)
                            {
                                if (!stringNull(title))
                                {
                                    post.Title = title;
                                    post.Content = content;
                                    post.LastModifiedTime = DateTime.Now;
                                    post.Modified = true;
                                    //post.Name = name;
                                    post.PostImage = image ?? "";
                                    post.Practice = _practiceSet && practice;
                                    post.VisibleState = visible;
                                    post.Approved = _approvedSet && approved;
                                    //修改
                                    AddTags(postId, tags);
                                    AddCategories(postId, categories);
                                    if (Service.PostsService.Update(post))
                                    {
                                        post.Tags = Service.TagsService.GetTagsByPostId(postId);
                                        post.Categories = Service.CategoriesService.CategoriesByPost(postId);
                                        isOk = true;
                                        res = new { post_id = postId, post_name = post.Name, tags = post.Tags.Select(p => p.Title), cats = post.Categories.Select(p => p.ID) };
                                    }
                                    else error = "on_update_error";
                                }
                                else error = "title_null";
                            }
                            else error = "post_null";
                        }
                        else error = "post_null";
                    }

                    #endregion

                    #region Rename

                    else if (mode == "rename")
                    {
                        if (postId > 0)
                        {
                            var post = Service.PostsService.GetPostById(postId);
                            if (post != null)
                            {
                                if (!stringNull(name))
                                {
                                    if (Regex.IsMatch(name, Validater.OtherName))
                                    {
                                        var nPost = Service.PostsService.GetPostByName(name);
                                        if (nPost == null || nPost.ID == post.ID)
                                        {
                                            if (post.Name == name)
                                                isOk = true;
                                            else
                                            {
                                                post.Name = name;
                                                if (Service.PostsService.Update(post, PostModified.Rename))
                                                    isOk = true;
                                                else error = "on_rename_error";
                                            }
                                        }
                                        else error = "has_name";
                                    }
                                    else error = "name_format";
                                }
                                else error = "name_null";
                            }
                            else error = "post_null";
                        }
                        else error = "post_null";
                    }

                    #endregion

                    //context.Response.Write(JsonConvert.SerializeObject(new { result = isOk ? "ok" : "no", errors = errors, res = retains }));
                    //return;
                    Result.Set(isOk, error, res);
                }
            }
            base.OnInit(e);
        }

        /// <summary>
        /// 修改标签关系
        /// </summary>
        /// <param name="postId">文章ID</param>
        /// <param name="isNew">是否新增文章</param>
        /// <param name="tags">新的标签标题</param>
        void AddTags(int postId, string[] tags, bool isNew = false)
        {
            //插入标签,获取所有标签
            var postTags = Service.TagsService.GetTagsByPostId(postId);
            if (tags == null) tags = new string[] { };
            if (tags.Length <= 0 && isNew) return;
            //修改标签
            //获取数据库中存在的标签
            var hasTags = tags.Length <= 0 ? new List<TagsModel>() : Service.TagsService.GetTagsByTitles(tags);
            //获取数据库中没有并且新增的标签
            var newTags = tags.Length <= 0 ? new List<string>() : tags.Where(t => !hasTags.Select(T => T.Title).Contains(t));
            //如果可以新增
            if (newTags.Count() > 0)
            {
                //新增标签
                Service.TagsService.AddRange(newTags.ToArray());
                hasTags = Service.TagsService.GetTagsByTitles(tags);
            }
            //添加关系
            if (hasTags.Count(p => !postTags.Select(t => t.ID).Contains(p.ID)) > 0)
            {
                //添加关系
                Service.PostInTagsService.Add(postId, hasTags.Where(p => !postTags.Select(t => t.ID).Contains(p.ID)).ToList());
            }
            if (!isNew)
            {
                //获取删除的标签
                var deleteTags = postTags.Where(p => !tags.Contains(p.Title));
                if (deleteTags.Count() > 0)
                {
                    //删除标签关系
                    Service.PostInTagsService.Delete(ModifiedMode.Self, deleteTags.Select(p => p.ID).ToArray());
                }
            }

        }

        /// <summary>
        /// 添加文章关系
        /// </summary>
        /// <param name="postId">文章ID</param>
        /// <param name="categories">新的分类</param>
        /// <param name="isNew">是否新的文章</param>
        void AddCategories(int postId, string[] categories, bool isNew = false)
        {
            if (categories == null) categories = new string[] { };
            if (categories.Length <= 0 && isNew) return;
            List<int> catIds = new List<int>();
            categories.ToList().ForEach(p =>
            {
                int id = 0;
                if (int.TryParse(p, out id) && id > 0)
                    catIds.Add(id);
            });
            if (isNew && catIds.Count <= 0) return;
            catIds = catIds.Distinct().ToList();
            //所有文章专辑
            var cats = Service.CategoriesService.GetList();
            //新增的专辑
            var newCats = cats.Where(p => catIds.Contains(p.ID));
            //获取文章专辑
            var postCats = isNew ? new List<CategoriesModel>() : Service.CategoriesService.CategoriesByPost(postId);
            //获取新增的标签
            var willAddCats = newCats.Where(c => !postCats.Select(p => p.ID).Contains(c.ID));
            if (willAddCats.Count() > 0)
            {
                //新增关系
                Service.PostInCategoriesService.AddForPost(postId, willAddCats.Select(p => p.ID).ToArray());
            }
            if (!isNew)
            {
                //删除的关系
                var deletedCats = postCats.Where(p => !newCats.Select(c => c.ID).Contains(p.ID));
                if (deletedCats.Count() > 0)
                {
                    var pinc = Service.PostInCategoriesService.GetList(postId, true);
                    Service.PostInCategoriesService.Delete(ModifiedMode.Self, pinc.Where(p => deletedCats.Select(d => d.ID).Contains(p.CategoryID)).Select(p => p.ID).ToArray());
                }
            }

        }
    }
}