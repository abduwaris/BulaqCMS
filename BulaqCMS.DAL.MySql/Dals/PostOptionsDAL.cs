using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.IDAL;
using MySql.Data.MySqlClient;
using System.Data;

namespace BulaqCMS.DAL.MySql
{
    public class PostOptionsDAL :BaseDAL<PostOptionsModel>, IPostOptionsDAL
    {
        /// <summary>
        /// 获取所有options
        /// </summary>
        /// <returns></returns>
        public List<PostOptionsModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}post_options`;", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据文章获取参数
        /// </summary>
        /// <param name="postid">文章 ID</param>
        /// <returns></returns>
        public List<PostOptionsModel> GetList(int postid)
        {
            string sql = string.Format("SELECT * FROM `{0}post_options` WHERE `{0}post_options`.`post_id` ={1}", Helper.Prefix, postid);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据ID集合获取参数
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<PostOptionsModel> GetList(params int[] ids)
        {
            string sql = string.Format("SELECT * FROM `{0}post_options` WHERE `{0}post_options`.`post_id` IN ({1});", Helper.Prefix, string.Join(",", ids));
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 新增文章参数
        /// </summary>
        /// <param name="option">文章参数</param>
        /// <returns></returns>
        public int Insert(PostOptionsModel option)
        {
            string sql = string.Format("INSERT `{0}post_options` (`{0}post_options`.`post_id`, `{0}post_options`.`option_key`, `{0}post_options`.`option_value`) VALUES(@id, @key, @val);", Helper.Prefix);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@id",option.PostID),
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value),
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="option">参数对象</param>
        /// <returns></returns>
        public int Update(PostOptionsModel option)
        {
            string sql = string.Format("UPDATE `{0}post_options` SET `{0}post_options`.`post_id`=@id, `{0}post_options`.`option_key` = @key, `{0}post_options`.`option_value` = @value WHERE `{0}post_options`.`option_id`={1};", Helper.Prefix);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@id",option.PostID),
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value),
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除的id</param>
        /// <param name="isPostid">是否根据文章删除</param>
        /// <returns></returns>
        public int Delete(int id, bool isPostid)
        {
            string sql = string.Format("DELETE FROM `{0}post_options` WHERE `{0}post_options`.`{1}_id`={2};", Helper.Prefix, isPostid ? "post" : "option", id);
            return Helper.Query(sql);
        }

        protected override PostOptionsModel ToModel(DataRow row)
        {
            PostOptionsModel op = new PostOptionsModel();
            if (row["option_id"] != null) op.ID = Convert.ToInt32(row["option_id"]);
            if (row["post_id"] != null) op.PostID = Convert.ToInt32(row["post_id"]);
            if (row["option_key"] != null) op.Key = row["option_key"].ToString();
            if (row["option_value"] != null) op.Value = row["option_value"].ToString();
            return op;
        }
    }
}
