using BulaqCMS.IDAL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.Common;
using System.Web;

namespace BulaqCMS.BLL
{
    public class UsersService : BaseService<IUsersDAL>
    {
        public UsersService() : base() { }
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.UserDAL;
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public UsersModel Login(string userName, string password)
        {
            UsersModel user = CurrentDAL.SelectByLoginName(userName);
            if (user != null && user.Password == PasswordHelper.CreateBulaqPassword(password))
                return user;
            return null;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">要创建的用户</param>
        /// <param name="errors">保存错误集合</param>
        /// <returns></returns>
        public bool CreateUser(UsersModel user, List<string> errors)
        {
            return Edit(user, CurrentDAL.GetList(), errors, true);
        }

        /// <summary>
        /// 根据 ID 获取用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public UsersModel One(int uid)
        {
            return CurrentDAL.GetList().FirstOrDefault(p => p.ID == uid);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user">要修改的用户</param>
        /// <param name="errors">错误集合</param>
        /// <returns></returns>
        public bool Update(UsersModel user, List<string> errors)
        {
            var users = CurrentDAL.GetList().Where(u => u.ID != user.ID);
            //判断用户是否存在
            return Edit(user, users.ToList(), errors, false);
        }
        /// <summary>
        /// 修改或新增
        /// </summary>
        /// <param name="user"></param>
        /// <param name="others"></param>
        /// <param name="errors"></param>
        /// <param name="isAdd"></param>
        /// <returns></returns>
        private bool Edit(UsersModel user, List<UsersModel> others, List<string> errors, bool isAdd)
        {
            var users = CurrentDAL.GetList();
            //判断用户是否存在
            if (users.Count(u => u.LoginName.ToLower() == user.LoginName.ToLower()) > 0) errors.Add("has_loginname");
            if (users.Count(u => u.Email == user.Email) > 0) errors.Add("has_email");
            if (errors.Count <= 0)
            {
                try
                {
                    return (isAdd ? CurrentDAL.Insert(user) : CurrentDAL.Update(user)) > 0;
                }
                catch
                {
                    errors.Add(isAdd ? "on_add_error" : "on_update_error");
                }
            }
            return false;
        }
    }
}
