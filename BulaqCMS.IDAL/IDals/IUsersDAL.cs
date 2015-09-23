using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.Models;

namespace BulaqCMS.IDAL
{
    public interface IUsersDAL
    {
        /// <summary>
        /// 根据登录名获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        UsersModel SelectByLoginName(string loginName);

        /// <summary>
        /// 根据 ID 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UsersModel GetUserById(int userId);

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user">要插入的用户</param>
        /// <returns></returns>
        int Insert(UsersModel user);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        List<UsersModel> GetList();

        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="user">修改数据的用户</param>
        /// <returns></returns>
        int Update(UsersModel user);

        /// <summary>
        /// 彻底删除用户
        /// </summary>
        /// <param name="userid">要删除的用户ID</param>
        /// <returns></returns>
        int Delete(int userid);

        /// <summary>
        /// 彻底删除用户
        /// </summary>
        /// <param name="user">要删除的用户</param>
        /// <returns></returns>
        int Delete(UsersModel user);
    }
}
