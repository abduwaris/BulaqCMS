using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using BulaqCMS.IDAL;

namespace BulaqCMS.DAL.MySql
{
    public class UsersDAL : BaseDAL<UsersModel>, IUsersDAL
    {
        /// <summary>
        /// 根据登录名获取用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns></returns>
        public UsersModel SelectByLoginName(string loginName)
        {
            string sql = string.Format("SELECT * FROM `{0}users` WHERE `{0}users`.`loginname`=@login;", Helper.Prefix);
            return ToModelList(Helper.Select(sql, new MySqlParameter("@login", loginName))).FirstOrDefault();
        }
        /// <summary>
        /// 根据ID 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UsersModel GetUserById(int id)
        {
            string sql = string.Format("select * from `{0}users` where `{0}users`.`user_id`={1};", Helper.Prefix, id);
            return ToModelList(Helper.Select(sql)).FirstOrDefault();
        }

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Insert(UsersModel user)
        {
            string sql = string.Format("INSERT `{0}users` (`{0}users`.`loginname`,`{0}users`.`displayname`,`{0}users`.`nicename`,`{0}users`.`password`,`{0}users`.`email`,`{0}users`.`url`,`{0}users`.`registertime`) VALUES(@loginname,@displayname,@nicename,@password,@email,@url,@registertime);", Helper.Prefix);
            MySqlParameter[] param = {
                        new MySqlParameter("@loginname",user.LoginName),
                        new MySqlParameter("@displayname",user.DisplayName), 
                        new MySqlParameter("@nicename",user.NiceName), 
                        new MySqlParameter("@password",user.Password), 
                        new MySqlParameter("@email",user.Email), 
                        new MySqlParameter("@url",user.Url), 
                        new MySqlParameter("@registertime",user.RegisterTime)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public List<UsersModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}users", Helper.Prefix);
            DataTable dt = Helper.Select(sql);
            return ToModelList(dt);
        }

        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="user">修改数据的用户</param>
        /// <returns></returns>
        public int Update(UsersModel user)
        {
            string sql = string.Format("UPDATE `{0}users` SET `{0}users`.`loginname`=@loginname,`{0}users`.`displayname`=@displayname,`{0}users`.`nicename`=@nicename,`{0}users`.`password`=@password,`{0}users`.`email`=@email,`{0}users`.`url`=@url,`{0}users`.`registertime`=@registertime WHERE `{0}users`.`user_id`=@userid");
            MySqlParameter[] param = {
                        new MySqlParameter("@loginname",user.LoginName),
                        new MySqlParameter("@displayname",user.DisplayName), 
                        new MySqlParameter("@nicename",user.NiceName), 
                        new MySqlParameter("@password",user.Password), 
                        new MySqlParameter("@email",user.Email), 
                        new MySqlParameter("@url",user.Url), 
                        new MySqlParameter("@registertime",user.RegisterTime), 
                        new MySqlParameter("@userid",user.ID)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 彻底删除用户
        /// </summary>
        /// <param name="userid">要删除的用户ID</param>
        /// <returns></returns>
        public int Delete(int userid)
        {
            string sql = string.Format("DELETE FROM `{0}users` WHERE `{0}users`.`user_id`={1};", Helper.Prefix, userid);
            return Helper.Query(sql);
        }

        /// <summary>
        /// 彻底删除用户
        /// </summary>
        /// <param name="user">要删除的用户</param>
        /// <returns></returns>
        public int Delete(UsersModel user)
        {
            return Delete(user.ID);
        }

        /// <summary>
        /// 转换成 Model
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected override UsersModel ToModel(DataRow row)
        {
            UsersModel user = new UsersModel();
            if (row["user_id"] != null) user.ID = Convert.ToInt32(row["user_id"]);
            if (row["loginname"] != null) user.LoginName = row["loginname"].ToString();
            if (row["displayname"] != null) user.DisplayName = row["displayname"].ToString();
            if (row["nicename"] != null) user.NiceName = row["nicename"].ToString();
            if (row["password"] != null) user.Password = row["password"].ToString();
            if (row["email"] != null) user.Email = row["email"].ToString();
            if (row["url"] != null) user.Url = row["url"].ToString();
            if (row["registertime"] != null) user.RegisterTime = Convert.ToDateTime(row["registertime"]);
            return user;
        }


    }
}
