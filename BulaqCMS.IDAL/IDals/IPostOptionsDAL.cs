using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface IPostOptionsDAL
    {
        /// <summary>
        /// 获取所有options
        /// </summary>
        /// <returns></returns>
        List<PostOptionsModel> GetList();

        /// <summary>
        /// 根据文章获取参数
        /// </summary>
        /// <param name="postid">文章 ID</param>
        /// <returns></returns>
        List<PostOptionsModel> GetList(int postid);

        /// <summary>
        /// 根据ID集合获取参数
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<PostOptionsModel> GetList(params int[] ids);

        /// <summary>
        /// 新增文章参数
        /// </summary>
        /// <param name="option">文章参数</param>
        /// <returns></returns>
        int Insert(PostOptionsModel option);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="option">参数对象</param>
        /// <returns></returns>
        int Update(PostOptionsModel option);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除的id</param>
        /// <param name="isPostid">是否根据文章删除</param>
        /// <returns></returns>
        int Delete(int id, bool isPostid);
    }
}
