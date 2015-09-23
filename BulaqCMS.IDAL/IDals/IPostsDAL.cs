using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface IPostsDAL
    {
        /// <summary>
        /// 根据作者获取文章个数
        /// </summary>
        /// <param name="catId">专辑</param>
        /// <param name="practice">批准</param>
        /// <param name="tagId">标签</param>
        /// <param name="authorid">作者id</param>
        /// <param name="isInRecycle">是否在回收站内</param>
        /// <param name="isDelflag">是否在垃圾</param>
        /// <param name="isApproved">是否批准</param>
        /// <returns></returns>
        int Count(int? catId = null, int? tagId = null, int? authorid = null, bool? isApproved = null, bool? isDelflag = null, bool? isPractice = null);

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
        /// <param name="pageSize">页容量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByMode">排序模式</param>
        /// <param name="categoryId">专辑ID</param>
        /// <param name="tagId">标签 ID</param>
        /// <param name="authorid">作者 ID</param>
        /// <param name="isApproved">是否批准</param>
        /// <param name="isInRecycle">回收站</param>
        /// <param name="isDelflag">删除标识</param>
        /// <returns></returns>
        List<PostsModel> GetPage(int pageSize, int pageIndex, PostsOrderByMode orderByMode, int? categoryId = null, int? tagId = null, int? authorid = null, bool? isApproved = null, bool? isDelflag = null, bool? isPractice = null);



        /// <summary>
        /// 根据 ID 获取文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PostsModel GetPost(int id);


        /// <summary>
        /// 根据评论ID获取文章
        /// </summary>
        /// <param name="comIds">评论 id 集合</param>
        /// <returns></returns>
        List<PostsModel> GetPostsByCommentsIds(params int[] comIds);

        /// <summary>
        /// 根据文章名获取文章
        /// </summary>
        /// <param name="name">文章名</param>
        /// <param name="isPage">是不是页扫描, 默认是文章</param>
        /// <returns></returns>
        PostsModel GetPost(string name, bool isPage = false);

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="post">要新增的对象</param>
        /// <param name="isPage">是不是页面</param>
        /// <returns></returns>
        int Insert(PostsModel post, bool isPage);

        /// <summary>
        /// 修改文章
        /// </summary>
        /// <param name="post"></param>
        /// <param name="modi"></param>
        /// <returns></returns>
        int Update(PostsModel post, PostModified modi);

        /// <summary>
        /// 全局修改
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        int Update(PostsModel post);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        int Delete(int pid);
    }
}
