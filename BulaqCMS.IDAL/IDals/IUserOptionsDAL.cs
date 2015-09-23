using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface IUserOptionsDAL
    {
        /// <summary>
        /// 获取用户的所有配置参数
        /// </summary>
        /// <param name="userid">要获取的用户id</param>
        /// <returns></returns>
         List<UserOptionsModel> GetList(int userid = -1);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="option">要修改的对象</param>
        /// <returns></returns>
         int Update(UserOptionsModel option);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">要删除的ID</param>
        /// <param name="isUserID">是不是根据用户删除</param>
        /// <returns></returns>
         int Delete(int id, bool isUserID);


        /// <summary>
        /// 插入参数
        /// </summary>
        /// <param name="option">要插入的对象</param>
        /// <returns></returns>
         int Insert(UserOptionsModel option);
    }
}
