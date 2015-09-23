using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.Models;
using BulaqCMS.IDAL;
using System.Data;
using MySql.Data.MySqlClient;

namespace BulaqCMS.DAL.MySql
{
    public class CommentOptionsDAL : BaseDAL<CommentOptionsModel>, ICommentOptionsDAL
    {
        /// <summary>
        /// 获取所有评论参数
        /// </summary>
        /// <returns></returns>
        public List<CommentOptionsModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}comment_options`;", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据评论获取她的参数
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        public List<CommentOptionsModel> GetList(int comId)
        {
            string sql = string.Format("SELECT * FROM `{0}comment_options` WHERE `{0}comment_options`.`com_id`={1};", Helper.Prefix, comId);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据ID获取一个
        /// </summary>
        /// <param name="optionId">参数ID</param>
        /// <returns></returns>
        public CommentOptionsModel One(int optionId)
        {
            string sql = string.Format("SELECT * FROM `{0}comment_options` WHERE `{0}comment_options`.`option_id`={1};", Helper.Prefix, optionId);
            return ToModelList(Helper.Select(sql)).FirstOrDefault();
        }

        /// <summary>
        /// 插入参数
        /// </summary>
        /// <param name="option">参数</param>
        /// <returns></returns>
        public int Insert(CommentOptionsModel option)
        {
            string sql = string.Format("INSERT `{0}comment_options`(`{0}comment_options`.`com_id`, `{0}comment_options`.`option_key`, `{0}comment_options`.`option_value`) Values(@comid,@key,@val);", Helper.Prefix);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@comid",option.CommentID),
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value),
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 修改参数
        /// </summary>
        /// <param name="option">参数</param>
        /// <returns></returns>
        public int Update(CommentOptionsModel option)
        {
            string sql = string.Format("UPDATE `{0}comment_options` SET `{0}comment_options`.`com_id`=@comid, `{0}comment_options`.`option_key`=@key, `{0}comment_options`.`option_value`=@val WHERE `{0}comment_options`.`option_id`={1};", Helper.Prefix, option.ID);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@comid",option.CommentID),
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value),
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除标识 ID</param>
        /// <param name="isByComment">根据评论还是主键删除</param>
        /// <returns></returns>
        public int Delete(int id, bool isByComment)
        {
            string sql = string.Format("DELETE FROM `{0}comment_options` WHERE `{0}comment_options`.`{1}_id`={2};", Helper.Prefix, isByComment ? "com" : "option", id);
            return Helper.Query(sql);
        }

        /// <summary>
        /// 根据摸个键删除
        /// </summary>
        /// <param name="isByComment">是否根据评论ID删除</param>
        /// <param name="ids">键集合</param>
        /// <returns></returns>
        public int Delete(bool isByComment, params int[] ids)
        {
            if (ids == null || ids.Length <= 0) return 0;
            string sql = string.Format("DELETE FROM `{0}comment_options` where `{0}comment_options`.`{1}_id` IN ({2});", Helper.Prefix, isByComment ? "com" : "option", string.Join(",", ids));
            return Helper.Query(sql);
        }

        protected override CommentOptionsModel ToModel(DataRow row)
        {
            CommentOptionsModel op = new CommentOptionsModel();
            if (row["option_id"] != null) op.ID = Convert.ToInt32(row["option_id"]);
            if (row["com_id"] != null) op.CommentID = Convert.ToInt32(row["com_id"]);
            if (row["option_key"] != null) op.Key = row["option_key"].ToString();
            if (row["option_value"] != null) op.Value = row["option_value"].ToString();
            return op;
        }
    }
}
