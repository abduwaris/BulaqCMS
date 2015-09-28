using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface INavGroupDAL
    {
        /// <summary>
        /// 获取所有菜单分类
        /// </summary>
        /// <returns></returns>
        List<NavGroupModel> GetList();

        /// <summary>
        /// 根据 name 获取菜单
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        NavGroupModel GetGroupByName(string name);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        int Insert(NavGroupModel group);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        int Update(NavGroupModel group);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);
    }
}
