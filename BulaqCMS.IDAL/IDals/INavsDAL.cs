using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface INavsDAL
    {
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        List<NavsModel> GetList();

        /// <summary>
        /// 根据菜单分类获取菜单
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        List<NavsModel> NavsByGroupId(int groupId);

        /// <summary>
        /// 根据分组获取
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        List<NavsModel> GetList(int groupId);

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="nav"></param>
        /// <returns></returns>
        int Insert(NavsModel nav);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="nav">要修改的对象</param>
        /// <returns></returns>
        int Update(NavsModel nav);

        /// <summary>
        /// 新的顺序
        /// </summary>
        /// <param name="navId"></param>
        /// <param name="newIndex"></param>
        /// <returns></returns>
        int NewIndex(int navId, short newIndex);

        /// <summary>
        /// 修改父级
        /// </summary>
        /// <param name="navId"></param>
        /// <param name="newParentId"></param>
        /// <returns></returns>
        int NewParent(int navId, int newParentId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除的ID</param>
        /// <returns></returns>
        int Delete(int id, bool isGroupId = false);
    }
}
