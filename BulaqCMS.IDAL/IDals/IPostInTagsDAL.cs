using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface IPostInTagsDAL
    {
        /// <summary>
        /// 获取所有标签关系
        /// </summary>
        /// <returns></returns>
        List<PostInTagsModel> GetList();

        /// <summary>
        /// 根据 ID 集合获取
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<PostInTagsModel> GetList(ModifiedMode mode, params int[] ids);

        /// <summary>
        /// 根据关系查找
        /// </summary>
        /// <param name="id">属性 ID</param>
        /// <param name="mode">模式</param>
        /// <returns></returns>
        List<PostInTagsModel> GetList(int id, ModifiedMode mode);

        /// <summary>
        /// 获取第一个
        /// </summary>
        /// <param name="tagID">标签</param>
        /// <param name="postID">文章</param>
        /// <returns></returns>
        PostInTagsModel One(int tagID, int postID);

        /// <summary>
        /// 获取第一个
        /// </summary>
        /// <param name="tpid">关西id</param>
        /// <returns></returns>
        PostInTagsModel One(int tpid);

        /// <summary>
        /// 插入关系
        /// </summary>
        /// <param name="postInTags">添加的对象</param>
        /// <returns></returns>
        int Insert(PostInTagsModel postInTags);

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        int Insert(params PostInTagsModel[] models);

        /// <summary>
        /// 修改关系
        /// </summary>
        /// <param name="postInTags">修改的对象</param>
        /// <returns></returns>
        int Update(PostInTagsModel postInTags);

        /// <summary>
        /// 删除关系
        /// </summary>
        /// <param name="id">删除 ID</param>
        /// <param name="mode">删除模式</param>
        /// <returns></returns>
        int Delete(int id, ModifiedMode mode);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        int Delete(ModifiedMode mode, params int[] ids);

        /// <summary>
        /// 根据关系删除
        /// </summary>
        /// <param name="postId">文章</param>
        /// <param name="tagId">标签</param>
        /// <returns></returns>
        int Delete(int postId, int tagId);
    }
}
