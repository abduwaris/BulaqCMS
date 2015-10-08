using BulaqCMS.IDAL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class CommentsService : BaseService<ICommentsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.CommentsDAL;
        }

        /// <summary>
        /// 获取文章评论关系,只读取 评论ID 和 文章ID
        /// </summary>
        /// <param name="postIds"></param>
        /// <returns></returns>
        public List<CommentsModel> CommentsInPosts(params int[] postIds)
        {
            return CurrentDAL.CommentsInPost(postIds);
        }

        /// <summary>
        /// 获取分页
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="totalCount">总数</param>
        /// <param name="postID">文章id</param>
        /// <param name="authorId">作者id</param>
        /// <param name="isDel">删除标识</param>
        /// <param name="isApproved">批准</param>
        /// <param name="isInRecycle">回收站</param>
        /// <param name="ip">ip</param>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        public List<CommentsModel> GetPage(int pageIndex, int pageSize, out int totalCount, bool includePosts = false, int? postID = null, int? authorId = null, bool? isDel = null, bool? isApproved = null, string ip = null, string email = null)
        {
            totalCount = Count(postID, authorId, isDel, isApproved, ip, email);
            var coms = CurrentDAL.GetPage(pageIndex, pageSize, CommentOrderByMode.ID_Desc, postID, authorId, isDel, isApproved, ip, email);
            if (includePosts && coms.Count > 0)
            {
                var posts = Service.PostsService.GetPostsByCommentsIds(coms.Select(c => c.ID).Distinct().ToArray());
                foreach (var com in coms)
                    com.Posts = posts.FirstOrDefault(p => p.ID == com.PostID);
            }
            return coms;
        }

        /// <summary>
        /// 获取总个数
        /// </summary>
        /// <param name="postID"></param>
        /// <param name="authorId"></param>
        /// <param name="isDel"></param>
        /// <param name="isApproved"></param>
        /// <param name="isInRecycle"></param>
        /// <param name="ip"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public int Count(int? postID = null, int? authorId = null, bool? isDel = null, bool? isApproved = null, string ip = null, string email = null)
        {
            return CurrentDAL.Count(postID, authorId, isDel, isApproved, ip, email);
        }

        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="allCount"></param>
        /// <param name="approvedCount"></param>
        /// <param name="delflagCount"></param>
        /// <param name="isInRecycleCount"></param>
        /// <returns></returns>
        public bool Count(ref int allCount, ref int approvedCount, ref int delflagCount)
        {
            return CurrentDAL.Count(ref  allCount, ref  approvedCount, ref  delflagCount);
        }

        /// <summary>
        /// 根据自己ID删除
        /// </summary>
        /// <param name="commentId">评论 ID</param>
        /// <param name="withOptions">是否删除评论</param>
        /// <param name="removeChildComments">是否删除子评论</param>
        /// <returns></returns>
        public int Delete(int commentId, bool withOptions, bool removeChildComments)
        {
            if (withOptions)
            {
                Service.CommentOptionsService.Delete(commentId, true);
            }
            //获取它的所有字评论
            var cComs = CurrentDAL.GetCommentsByParentId(commentId);
            //删除
            if (cComs.Count > 0 && removeChildComments) DeleteByParent(commentId);
            else if (cComs.Count > 0)
            {
                //移动
                var pCom = CurrentDAL.GetCommentById(commentId);
                CurrentDAL.MoveParent(pCom.ParentID, commentId);
            }
            return CurrentDAL.Delete(commentId, false);
        }



        public bool DeleteByParent(int parentId)
        {
            //获取它的所有字评论
            var cComs = CurrentDAL.GetCommentsByParentId(parentId);
            foreach (var com in cComs)
            {
                var ccComs = CurrentDAL.GetCommentsByParentId(com.ID);
                if (ccComs.Count > 0) DeleteByParent(com.ID);
            }
            return true;
        }


        /// <summary>
        /// 根据文章删除评论
        /// </summary>
        /// <param name="withOptions">是否删除评论参数</param>
        /// <param name="postId">文章ID</param>
        /// <returns></returns>
        public int Delete(int postId)
        {
            var coms = CommentsInPosts(postId);
            if (coms==null||coms.Count<=0)
            {
                return 0;
            }
            //删除评论参数
            Service.CommentOptionsService.Delete(true, coms.Select(p => p.ID).ToArray());
            //删除评论
            return CurrentDAL.Delete(postId, true);
        }

        /// <summary>
        /// 根据ID获取评论
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public CommentsModel GetCommentById(int commentId)
        {
            return CurrentDAL.GetCommentById(commentId);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool Update(CommentsModel comment)
        {
            return CurrentDAL.Update(comment, CommentModified.All) > 0;
        }
        /// <summary>
        /// 删除表示
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public bool UpdateDelFlag(CommentsModel comment)
        {
            return CurrentDAL.Update(comment, CommentModified.Del) > 0;
        }
    }
}
