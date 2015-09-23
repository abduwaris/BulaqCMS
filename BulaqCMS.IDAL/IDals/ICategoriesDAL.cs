using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface ICategoriesDAL
    {
        /// <summary>
        /// 获取所有专辑
        /// </summary>
        /// <returns></returns>
        List<CategoriesModel> GetList();

        /// <summary>
        /// 获取一堆
        /// </summary>
        /// <param name="id">条件 ID</param>
        /// <param name="isParentId">是不是跟父查找</param>
        /// <returns></returns>
        List<CategoriesModel> GetList(int id, bool isParentId);

        /// <summary>
        /// 根据文章查找
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        List<CategoriesModel> GetList(int postId);

        /// <summary>
        /// 根据别名获取专辑
        /// </summary>
        /// <param name="name">别名</param>
        /// <returns></returns>
        CategoriesModel One(string name);

        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        CategoriesModel One(int catId);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="cat">对象</param>
        /// <returns></returns>
        int Insert(CategoriesModel cat);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        int Update(CategoriesModel cat);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除 ID</param>
        /// <param name="isParentId">是否根据父删除</param>
        /// <returns></returns>
        int Delete(int id, bool isParentId);

        /// <summary>
        /// 父子修改
        /// </summary>
        /// <param name="oldParentId">久父</param>
        /// <param name="newParentId">新父</param>
        /// <returns></returns>
        int MoveParent(int oldParentId, int newParentId);
    }
}
