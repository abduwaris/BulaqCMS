using BulaqCMS.IDAL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class PostsService : BaseService<IPostsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.PostsDAL;
        }

        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="pageSize">页码</param>
        /// <param name="pageIndex">页容量</param>
        /// <param name="categoryId">专辑</param>
        /// <param name="totalCount">总页数</param>
        /// <param name="tagId">标签</param>
        /// <param name="authorId">作者</param>
        /// <param name="isApproved">批准</param>
        /// <param name="isInRecycle">回收站</param>
        /// <param name="isDelFlag">删除</param>
        /// <returns></returns>
        public List<PostsModel> GetPostsByPage(int pageSize, int pageIndex, out int totalCount, int? categoryId = null, int? tagId = null, int? authorId = null, bool? isApproved = null, bool? isDelFlag = null, bool? isPractice = null)
        {
            totalCount = CurrentDAL.Count(categoryId, tagId, authorId, isApproved, isDelFlag, isPractice);
            return CurrentDAL.GetPostsByPage(pageSize, pageIndex, PostsOrderByMode.ID_Desc, categoryId, tagId, authorId, isApproved, isDelFlag);
        }

        public List<PostsModel> OpenPages(int pageSize, int pageIndex, out int totalCount)
        {
            return GetPostsByPage(pageSize, pageIndex, out totalCount, null, null, null, true, false, false);

        }

        /// <summary>
        /// 根据评论获取文章
        /// </summary>
        /// <param name="comIds"></param>
        /// <returns></returns>
        public List<PostsModel> GetPostsByCommentsIds(params int[] comIds)
        {
            return CurrentDAL.GetPostsByCommentsIds(comIds);
        }
        /// <summary>
        /// 根据评论获取文章
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        public PostsModel GetPostByCommentId(int comId)
        {
            return GetPostsByCommentsIds(comId).FirstOrDefault();
        }

        /// <summary>
        /// 根据条件获取
        /// </summary>
        /// <param name="pageSize">页码</param>
        /// <param name="pageIndex">页容量</param>
        /// <param name="categoryId">专辑</param>
        /// <param name="totalCount">总页数</param>
        /// <param name="tagId">标签</param>
        /// <param name="authorId">作者</param>
        /// <param name="isApproved">批准</param>
        /// <param name="isInRecycle">回收站</param>
        /// <param name="isDelFlag">删除</param>
        /// <param name="includeAuthor">是否引入作者</param>
        /// <param name="includeCommentsCount">是否引入品论个数</param>
        /// <param name="isPractice">是否草稿</param>
        /// <param name="includeCategories">是否引入专辑</param>
        /// <param name="includeTags">是否引入标签</param>
        /// <returns></returns>
        public List<PostsModel> GetPostsByPage(int pageSize, int pageIndex, out int totalCount, bool includeCommentsCount = false, bool includeAuthor = false, bool includeCategories = false, bool includeTags = false, int? categoryId = null, int? tagId = null, int? authorId = null, bool? isApproved = null, bool? isDelFlag = null, bool? isPractice = null)
        {
            totalCount = CurrentDAL.Count(categoryId, tagId, authorId, isApproved, isDelFlag, isPractice);
            var posts = CurrentDAL.GetPostsByPage(pageSize, pageIndex, PostsOrderByMode.ID_Desc, categoryId, tagId, authorId, isApproved, isDelFlag);
            if (includeCommentsCount || includeAuthor || includeCategories || includeTags)
            {
                //获取所有文章的个数关联
                List<CommentsModel> coms = null;
                if (includeCommentsCount) coms = DAL.CommentsDAL.CommentsInPost(posts.Select(p => p.ID).ToArray());
                List<UsersModel> author = null;
                if (includeAuthor) author = DAL.UserDAL.GetList();
                List<CategoriesModel> cats = null;
                List<PostInCategoriesModel> catIn = null;
                if (includeCategories)
                {
                    cats = DAL.CategoriesDAL.GetList();
                    catIn = DAL.PostInCategoriesDAL.GetList();
                }

                List<TagsModel> tags = null;
                List<PostInTagsModel> tagIn = null;
                if (includeTags)
                {
                    tagIn = DAL.PostInTagsDAL.GetList(ModifiedMode.Post, posts.Select(p => p.ID).ToArray());
                    tags = DAL.TagsDAL.GetList(tagIn.Select(p => p.TagID).ToArray());
                }

                foreach (var post in posts)
                {
                    if (includeCommentsCount) post.CommentsCount = coms.Count(p => p.PostID == post.ID);
                    if (includeAuthor) post.Author = author.FirstOrDefault(p => p.ID == post.AuthorID);
                    if (includeCategories) post.Categories = cats.Where(p => catIn.Where(c => c.PostID == post.ID).Select(c => c.CategoryID).Contains(p.ID)).ToList();

                    if (includeTags) post.Tags = tags.Where(p => tagIn.Where(c => c.PostID == post.ID).Select(c => c.TagID).Contains(p.ID)).ToList();
                }
            }
            return posts;
        }

        /// <summary>
        /// 获取所有页面
        /// </summary>
        /// <returns></returns>
        public List<PostsModel> GetPages()
        {
            return CurrentDAL.GetPages();
        }

        /// <summary>
        /// 获取可以显示的页面
        /// </summary>
        /// <returns></returns>
        public List<PostsModel> GetOpenPages()
        {
            return GetPages().Where(p => p.Approved).ToList();
        }

        public PostsModel GetPostById(int id)
        {
            return CurrentDAL.GetPost(id);
        }

        /// <summary>
        /// 所有文章个数
        /// </summary>
        /// <returns></returns>
        public int AllCount()
        {
            return CurrentDAL.Count();
        }

        /// <summary>
        /// 待批准的个数
        /// </summary>
        /// <returns></returns>
        public int NotApproveCount()
        {
            return CurrentDAL.Count(isApproved: false);
        }

        /// <summary>
        /// 删除标识个数
        /// </summary>
        /// <returns></returns>
        public int DelFlagCount()
        {
            return CurrentDAL.Count(isDelflag: true);
        }



        /// <summary>
        /// 根据文章名获取文章
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PostsModel GetPostByName(string name)
        {
            return CurrentDAL.GetPost(name);
        }

        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public bool Add(PostsModel post)
        {
            return CurrentDAL.Insert(post, post.PostType) > 0;
        }

        /// <summary>
        /// 修改当前的文章
        /// </summary>
        /// <param name="post"></param>
        /// <param name="modified">修改表示, 只可以包含以下
        /// Save 
        /// Send
        /// Image
        /// Approve
        /// Recycle
        /// DelFlag
        /// Practice
        /// </param>
        /// <returns></returns>
        public bool Update(PostsModel post, PostModified mode)
        {
            return CurrentDAL.Update(post, mode) > 0;
        }

        /// <summary>
        /// 完全修改
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public bool Update(PostsModel post)
        {
            return CurrentDAL.Update(post) > 0;
        }

        /// <summary>
        /// 根据文章id 删除
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public bool Delete(int postId)
        {
            //删除所有评论
            //      删除评论参数
            Service.CommentsService.Delete(postId);
            //删除标签关系
            Service.PostInTagsService.Delete(postId, ModifiedMode.Post);
            //删除分类关系
            Service.PostInCategoriesService.Delete(postId, false);
            //删除文章参数
            Service.PostOptionsService.Delete(postId, true);
            //删除 自己
            return CurrentDAL.Delete(postId) > 0;
        }
    }
}
