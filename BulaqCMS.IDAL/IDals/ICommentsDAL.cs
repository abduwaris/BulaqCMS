using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface ICommentsDAL
    {
        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="postID">文章</param>
        /// <param name="authorId">作者</param>
        /// <param name="isDel">删除标识</param>
        /// <param name="isApproved">批准</param>
        /// <param name="isInRecycle">回收站</param>
        /// <param name="ip">IP</param>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        int Count(int? postID = null, int? authorId = null, bool? isDel = null, bool? isApproved = null, string ip = null, string email = null);

        /// <summary>
        /// 获取个数
        /// </summary>
        /// <param name="allCount"></param>
        /// <param name="approvedCount"></param>
        /// <param name="delflagCount"></param>
        /// <param name="isInRecycleCount"></param>
        /// <returns></returns>
        bool Count(ref int allCount, ref int approvedCount, ref int delflagCount);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="orderByMode">排序方式</param>
        /// <param name="postID">文章 ID</param>
        /// <param name="authorId">作者ID</param>
        /// <param name="isDel">删除标识</param>
        /// <param name="isApproved">批准</param>
        /// <param name="isInRecycle">回收站</param>
        /// <returns></returns>
        List<CommentsModel> GetPage(int pageIndex, int pageSize, CommentOrderByMode orderByMode, int? postID = null, int? authorId = null, bool? isDel = null, bool? isApproved = null, string ip = null, string email = null);

        /// <summary>
        /// 获取文章评论关系,只读取 评论ID 和 文章ID
        /// </summary>
        /// <param name="postIds"></param>
        /// <returns></returns>
        List<CommentsModel> CommentsInPost(params int[] postIds);

        /// <summary>
        /// 根据ID获取评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CommentsModel GetCommentById(int id);

        /// <summary>
        /// 根据父评论ID获取评论
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<CommentsModel> GetCommentsByParentId(int parentId);
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        int Insert(CommentsModel com);

        /// <summary>
        /// 修改评论
        /// </summary>
        /// <param name="com">要修改评论</param>
        /// <param name="mode">修改模式</param>
        /// <returns></returns>
        int Update(CommentsModel com, CommentModified mode);

        /// <summary>
        /// 移动评论父
        /// </summary>
        /// <param name="newParentId"></param>
        /// <param name="oldParentId"></param>
        /// <returns></returns>
        int MoveParent(int newParentId, int oldParentId);

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="id">删除id</param>
        /// <param name="isPostId">根据什么删除,是不是post</param>
        /// <returns></returns>
        int Delete(int id, bool isPostId = false);

        /// <summary>
        /// 根据评论父删除
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        int DeleteByParentId(int parentId);
    }
}
