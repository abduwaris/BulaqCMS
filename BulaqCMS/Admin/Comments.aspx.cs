﻿using BulaqCMS.BLL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulaqCMS.Admin
{
    public partial class Comments : AdminBasePage
    {

        /// <summary>
        /// 当前业内的评论
        /// </summary>
        protected List<CommentsModel> nowComments;

        /// <summary>
        /// 页码
        /// </summary>
        protected int pageIndex = 1;

        /// <summary>
        /// 评论总个数(当前条件下的)
        /// </summary>
        protected int totalCount;

        /// <summary>
        /// 页容量
        /// </summary>
        protected int pageSize = 20;

        protected int pageCount;

        /// <summary>
        /// 浏览模式
        /// </summary>
        protected string view;

        protected int allCount = 0;
        protected int aprovedCount = 0;
        protected int delFlagCount = 0;
        protected int recycleCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            QueryString = new Dictionary<string, object>();
            /// postID
            /// pageIndex
            /// email
            /// uname,
            /// userId
            /// ip
            string[] views = { "all", "notaproved", "aproved", "delflag" };
            view = string.IsNullOrEmpty(Request.QueryString["view"]) ? "all" : Request.QueryString["view"].Trim().ToLower();
            if (!views.Contains(view)) view = "all";
            bool? approved = view == "notaproved" ? (bool?)false : view == "aproved" ? (bool?)true : null;
            bool? delfalg = view == "delflag" ? (bool?)true : null;

            QueryString["view"] = view;
            //筛选
            //Email
            string email = string.IsNullOrEmpty(Request.QueryString["email"]) ? null : Request.QueryString["email"].Trim();
            if (email != null) QueryString["email"] = email;
            //文章
            int? postId = null;
            int postIdd = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["postid"]) && int.TryParse(Request.QueryString["postid"].Trim(), out postIdd)) postId = postIdd;
            if (postId != null) QueryString["postid"] = postId;
            //IP
            string ip = string.IsNullOrEmpty(Request.QueryString["ip"]) ? null : Request.QueryString["ip"].Trim();
            if (ip != null) QueryString["ip"] = ip;
            //作者
            int? authorId = null;
            int authorIdd = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["author"]) && int.TryParse(Request.QueryString["author"].Trim(), out authorIdd)) authorId = authorIdd;
            if (authorId != null) QueryString["author"] = authorId;
            //页码
            pageIndex = string.IsNullOrEmpty(Request.QueryString["page"]) ? 1 : int.TryParse(Request.QueryString["page"].Trim(), out pageIndex) ? pageIndex : 1;

            nowComments = Service.CommentsService.GetPage(pageIndex, pageSize, out totalCount, true, postId, authorId, delfalg, approved, ip, email);

            pageCount = Convert.ToInt32(Math.Ceiling(totalCount / (double)pageSize));
            if (pageCount <= 0) pageCount = 1;

            //获取个数
            Service.CommentsService.Count(ref allCount, ref aprovedCount, ref delFlagCount);

        }


        public override string ActivePage
        {
            get
            {
                return "post-comments";
            }
        }


        protected override void OnInit(EventArgs e)
        {
            if (Method == HttpMethod.HttpPost)
            {
                var frm = Request.Form;
                string[] modes = { "delete", "delflag" };
                string mode = stringNull(frm["Mode"]) ? null : frm["Mode"].Trim().ToLower();
                if (modes.Contains(mode))
                {
                    string error = null;
                    bool isOk = false;
                    if (mode == "delete")
                    {
                        //删除
                        int comId = 0;
                        if (stringNull(frm["CommentID"]) || !int.TryParse(frm["CommentID"].Trim(), out comId) || Service.CommentsService.GetCommentById(comId) == null) error = "delete_comment_null";
                        else
                        {
                            if (Service.CommentsService.Delete(comId, true, true) > 0) isOk = true;
                            else error = "on_delete_error";
                        }
                    }
                    else if (mode == "delflag")
                    {
                        int comId = 0;
                        bool state = false;
                        if (stringNull(frm["CommentID"]) || !int.TryParse(frm["CommentID"].Trim(), out comId)) error = "del_comment_null";
                        else if (stringNull(frm["State"]) || !bool.TryParse(frm["State"].Trim(), out state)) error = "del_state_null";
                        else
                        {
                            var com = Service.CommentsService.GetCommentById(comId);
                            if (com == null) error = "del_comment_null";
                            else
                            {
                                com.DelFlag = state;
                                if (Service.CommentsService.UpdateDelFlag(com)) isOk = true;
                                else error = "on_delflag_error";
                            }
                        }
                    }

                    Result.SetResult(isOk).SetError(error);
                }
            }

            base.OnInit(e);
        }
    }
}