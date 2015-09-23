using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.Models;
using BulaqCMS.IDAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace BulaqCMS.DAL.MySql
{
    public class UserOptionsDAL:BaseDAL<UserOptionsModel>, IUserOptionsDAL
    {
        /// <summary>
        /// 获取用户的所有配置参数
        /// </summary>
        /// <param name="userid">要获取的用户id</param>
        /// <returns></returns>
        public List<UserOptionsModel> GetList(int userid = -1)
        {
            string sql = string.Format("SELECT * FROM `{0}user_options`{1};", Helper.Prefix, userid > 0 ? string.Format(" WHERE `{0}user_options`.`user_id` = {1}", Helper.Prefix, userid) : "");
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public int Update(UserOptionsModel option)
        {
            string sql = string.Format("UPDATE `{0}user_options` SET `{0}user_options`.`user_id`=@uid,`{0}user_options`.`option_key`=@key,`{0}user_options`.`option_value`=@val WHERE `{0}user_options`.`option_id`=@id", Helper.Prefix);
            MySqlParameter[] param = {
                                     new MySqlParameter("@uid",option.UserID),
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value),
                                     new MySqlParameter("@id",option.ID)
                                     };
            return Helper.Query(sql, param);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">要删除的ID</param>
        /// <param name="isUserID">是不是根据用户删除</param>
        /// <returns></returns>
        public int Delete(int id, bool isUserID)
        {
            string sql = string.Format("DELETE FROM `{0}user_options` WHERE `{0}user_options`.`{1}_id`={2};", Helper.Prefix, isUserID ? "user" : "option", id);
            return Helper.Query(sql);
        }

        /// <summary>
        /// 插入参数
        /// </summary>
        /// <param name="option">要插入的对象</param>
        /// <returns></returns>
        public int Insert(UserOptionsModel option)
        {
            string sql = string.Format("INSERT `{0}user_options` (`{0}user_options`.`user_id`,`{0}user_options`.`option_key`,`{0}user_options`.`option_value` ) VALUES(@uid,@key,@value);");
            MySqlParameter[] param = {
                                     new MySqlParameter("@uid",option.UserID),
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value)
                                     };
            return Helper.Query(sql, param);

        }

        protected override UserOptionsModel ToModel(DataRow row)
        {
            UserOptionsModel op = new UserOptionsModel();
            if (row["option_id"] != null) op.ID = Convert.ToInt32(row["option_id"]);
            if (row["user_id"] != null) op.UserID = Convert.ToInt32(row["user_id"]);
            if (row["option_key"] != null) op.Key = row["option_key"].ToString();
            if (row["option_value"] != null) op.Key = row["option_value"].ToString();
            return op;
        }
    }
}
