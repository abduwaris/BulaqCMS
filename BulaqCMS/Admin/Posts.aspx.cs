﻿using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            _queryString = new Dictionary<string, object>();
            //获取浏览对象
            string[] views = { "all", "aprove", "delflag" };
            view = string.IsNullOrEmpty(Request.QueryString["view"]) ? "all" : Request.QueryString["view"].Trim().ToLower();
            if (!views.Contains(view)) view = "all";
            bool? isAprove = view == "aprove" ? (bool?)false : null;
            bool? isDelfalg = view == "delflag" ? (bool?)true : null;
            _queryString.Add("view", view);
            //专辑
            int? catId = null;
            if (!string.IsNullOrEmpty(Request.QueryString["cat"]))
            {
                int catIdb;
                if (int.TryParse(Request.QueryString["cat"].Trim(), out catIdb))
                    if (catIdb >= 0)
                    {
                        catId = catIdb;
                        _queryString["cat"] = catIdb;
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
                        _queryString["tag"] = tagIdb;
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
                        _queryString["author"] = authorIdb;
                    }
            }

            //页码
            pageIndex = !string.IsNullOrEmpty(Request["page"]) && int.TryParse(Request["page"], out pageIndex) ? Convert.ToInt32(Request["page"]) : 1;
            postList = Service.PostsService.GetPage(pageSize, pageIndex, out totalCount, false, true, true, true, catId, tagId, authorId, isAprove, isDelfalg);
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

        /// <summary>
        /// url 参数
        /// </summary>
        private Dictionary<string, object> _queryString;

        /// <summary>
        /// 创建Url 参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public HtmlString CreateQueryString(string key, object value)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>(_queryString);
            dic[key] = value;
            return new HtmlString(string.Join("&", dic.Select(p => p.Key + "=" + p.Value)));
        }
    }
}