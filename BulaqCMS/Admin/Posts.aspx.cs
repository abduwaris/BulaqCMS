using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class Posts : AdminBasePage
    {
        /// <summary>
        /// 数据总量
        /// </summary>
        protected int totalCount = 0;

        /// <summary>
        /// 总页数
        /// </summary>
        protected int pageCount = 1;

        /// <summary>
        /// 页码
        /// </summary>
        protected int pageIndex = 1;

        /// <summary>
        /// 页容量
        /// </summary>
        protected int pageSize = 20;

        /// <summary>
        /// 当前业内的文章集合
        /// </summary>
        protected List<PostsModel> postList;

        /// <summary>
        /// 当前文章集合中 评论, 只包含评论ID 和 文章ID
        /// </summary>
        protected List<CommentsModel> commentsInPosts;

        /// <summary>
        /// 带批准个数
        /// </summary>
        protected int notApprovedCount;

        /// <summary>
        /// 已删除标识个数
        /// </summary>
        protected int delFlagCount;

        /// <summary>
        /// 所有文章个数
        /// </summary>
        protected int allCount;

        /// <summary>
        /// 浏览模式
        /// </summary>
        protected string view;
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryString = new Dictionary<string, object>();
            //获取浏览对象
            string[] views = { "all", "aprove", "delflag", "search" };
            view = string.IsNullOrEmpty(Request.QueryString["view"]) ? "all" : Request.QueryString["view"].Trim().ToLower();
            if (!views.Contains(view)) view = "all";
            bool? isAprove = view == "aprove" ? (bool?)false : null;
            bool? isDelfalg = view == "delflag" ? (bool?)true : null;
            QueryString.Add("view", view);
            //专辑
            int? catId = null;
            if (!string.IsNullOrEmpty(Request.QueryString["cat"]))
            {
                int catIdb;
                if (int.TryParse(Request.QueryString["cat"].Trim(), out catIdb))
                    if (catIdb >= 0)
                    {
                        catId = catIdb;
                        QueryString["cat"] = catIdb;
                    }
            }

            //标签
            int? tagId = null;
            if (!string.IsNullOrEmpty(Request.QueryString["tag"]))
            {
                int tagIdb;
                if (int.TryParse(Request.QueryString["tag"].Trim(), out tagIdb))
                    if (tagIdb >= 0)
                    {
                        tagId = tagIdb;
                        QueryString["tag"] = tagIdb;
                    }
            }

            //作者
            int? authorId = null;
            if (!string.IsNullOrEmpty(Request.QueryString["author"]))
            {
                int authorIdb;
                if (int.TryParse(Request.QueryString["author"].Trim(), out authorIdb))
                    if (authorIdb >= 0)
                    {
                        authorId = authorIdb;
                        QueryString["author"] = authorIdb;
                    }
            }

            //页码
            pageIndex = !string.IsNullOrEmpty(Request["page"]) && int.TryParse(Request["page"], out pageIndex) ? Convert.ToInt32(Request["page"]) : 1;
            postList = Service.PostsService.GetPostsByPage(pageSize, pageIndex, out totalCount, false, true, true, true, catId, tagId, authorId, isAprove, isDelfalg);
            commentsInPosts = postList.Count > 0 ? Service.CommentsService.CommentsInPosts(postList.Select(p => p.ID).ToArray()) : new List<CommentsModel>();
            //获取个数
            allCount = Service.PostsService.AllCount();
            notApprovedCount = Service.PostsService.NotApproveCount();
            delFlagCount = Service.PostsService.DelFlagCount();

            pageCount = Convert.ToInt32(Math.Ceiling(totalCount / (pageSize * 1.0)));
        }

        public override string ActivePage
        {
            get
            {
                return "post-posts";
            }
        }


        public HtmlString CreatePages()
        {
            StringBuilder sb = new StringBuilder();
            if (pageCount <= 1) return null;
            sb.Append("<ul class=\"pagination pagination-sm\">");
            //上一页按钮
            sb.Append("<li");
            if (pageIndex == 1)
            {
                sb.Append(" class=\"disabled\">");
                sb.Append("<a aria-label=\"Previous\"><span aria-hidden=\"true\">&laquo;</span></a>");
                sb.Append("</li>");
            }
            else
            {
                sb.Append("><a href=\"?");
                sb.Append(CreateQueryString("page", pageIndex - 1));
                sb.Append("\" aria-label=\"Previous\"><span aria-hidden=\"true\">&laquo;</span></a></li>");
            }

            //页
            if (pageCount <= 8)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    //<li class=""><a href="#">1</a></li>
                    sb.Append("<li");
                    if (pageIndex == i)
                        sb.Append(" class=\"active disabled\"");
                    sb.Append("><a");
                    if (pageIndex != i)
                        sb.Append(string.Format(" href=\"?{0}\"", CreateQueryString("page", i)));
                    sb.Append(string.Format(">{0}</a></li>", i));
                }
            }
            else
            {
                if (pageIndex <= 4)
                {
                    for (int i = 1; i <= 7; i++)
                    {
                        sb.Append("<li");
                        if (pageIndex == i)
                            sb.Append(" class=\"active disabled\"");
                        sb.Append("><a");
                        if (pageIndex != i)
                            sb.Append(string.Format(" href=\"?{0}\"", CreateQueryString("page", i)));
                        sb.Append(string.Format(">{0}</a></li>", i));
                    }
                    sb.Append("<li><a>...</a></li>");
                }
                else if (pageIndex <= pageCount - 4)
                {
                    sb.Append("<li><a>...</a></li>");
                    for (int i = pageCount - 7; i <= pageCount; i++)
                    {
                        sb.Append("<li");
                        if (pageIndex == i)
                            sb.Append(" class=\"active disabled\"");
                        sb.Append("><a");
                        if (pageIndex != i)
                            sb.Append(string.Format(" href=\"?{0}\"", CreateQueryString("page", i)));
                        sb.Append(string.Format(">{0}</a></li>", i));
                    }
                }
                else
                {
                    sb.Append("<li><a>...</a></li>");
                    for (int i = pageIndex - 3; i <= pageIndex + 3; i++)
                    {
                        sb.Append("<li");
                        if (pageIndex == i)
                            sb.Append(" class=\"active disabled\"");
                        sb.Append("><a");
                        if (pageIndex != i)
                            sb.Append(string.Format(" href=\"?{0}\"", CreateQueryString("page", i)));
                        sb.Append(string.Format(">{0}</a></li>", i));
                    }
                    sb.Append("<li><a>...</a></li>");
                }
            }

            //下一页
            sb.Append("<li");
            if (pageIndex == pageCount)
            {
                sb.Append(" class=\"disabled\">");
                sb.Append("<a aria-label=\"Next\"><span aria-hidden=\"true\">&raquo;</span></a>");
                sb.Append("</li>");
            }
            else
            {
                sb.Append("><a href=\"?");
                sb.Append(CreateQueryString("page", pageIndex + 1));
                sb.Append("\" aria-label=\"Next\"><span aria-hidden=\"true\">&raquo;</span></a></li>");
            }

            sb.Append("</ul>");
            return new HtmlString(sb.ToString());
        }
    }
}