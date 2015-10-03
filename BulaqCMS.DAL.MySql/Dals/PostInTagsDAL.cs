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
    public class PostInTagsDAL : BaseDAL<PostInTagsModel>, IPostInTagsDAL
    {
        /// <summary>
        /// 获取所有标签关系
        /// </summary>
        /// <returns></returns>
        public List<PostInTagsModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}post_in_tags`;", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据 ID 集合获取
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<PostInTagsModel> GetList(ModifiedMode mode, params int[] ids)
        {
            if (ids == null || ids.Length <= 0) return new List<PostInTagsModel>();
            string sql = string.Format("select `{0}post_in_tags`.* from `{0}post_in_tags` where `{0}post_in_tags`.`{2}_id` IN({1});", Helper.Prefix, string.Join(",", ids), mode == ModifiedMode.Post ? "post" : mode == ModifiedMode.TagOrCategoriy ? "tag" : "tp");
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据关系查找
        /// </summary>
        /// <param name="id">属性 ID</param>
        /// <param name="mode">模式</param>
        /// <returns></returns>
        public List<PostInTagsModel> GetList(int id, ModifiedMode mode)
        {
            string sql = string.Format("SELECT * FROM `{0}post_in_tags` WHERE `{0}post_in_tags`.`{1}_id`={2}", Helper.Prefix, mode == ModifiedMode.Self ? "tp" : mode == ModifiedMode.Post ? "post" : "tag", id);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 获取第一个
        /// </summary>
        /// <param name="tagID">标签</param>
        /// <param name="postID">文章</param>
        /// <returns></returns>
        public PostInTagsModel One(int tagID, int postID)
        {
            string sql = string.Format("SELECT * FROM `{0}post_in_tags` WHERE `{0}post_in_tags`.`post_id`={1} AND `{0}post_in_tags`.`tag_id`={2};", Helper.Prefix, postID, tagID);
            return ToModelList(Helper.Select(sql)).FirstOrDefault();
        }

        /// <summary>
        /// 获取第一个
        /// </summary>
        /// <param name="tpid">关西id</param>
        /// <returns></returns>
        public PostInTagsModel One(int tpid)
        {
            return GetList(tpid, ModifiedMode.Self).FirstOrDefault();
        }

        /// <summary>
        /// 插入关系
        /// </summary>
        /// <param name="postInTags">添加的对象</param>
        /// <returns></returns>
        public int Insert(PostInTagsModel postInTags)
        {
            string sql = string.Format("INSERT `{0}post_in_tags` (`{0}post_in_tags`.`tag_id`, `{0}post_in_tags`.`post_id`) VALUES({1}, {2});", Helper.Prefix, postInTags.TagID, postInTags.PostID);
            return Helper.Query(sql);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int Insert(params PostInTagsModel[] models)
        {
            if (models == null || models.Length <= 0) return 0;
            string sql = string.Format("INSERT `{0}post_in_tags` (`{0}post_in_tags`.`tag_id`, `{0}post_in_tags`.`post_id`) VALUES{1};", Helper.Prefix, string.Join(",", models.Select(p => string.Format("({0},{1})", p.TagID, p.PostID))));
            return Helper.Query(sql);
        }

        /// <summary>
        /// 修改关系
        /// </summary>
        /// <param name="postInTags">修改的对象</param>
        /// <returns></returns>
        public int Update(PostInTagsModel postInTags)
        {
            string sql = string.Format("UPDATE `{0}post_in_tags` SET `{0}post_in_tags`.`tag_id` = {1}, `{0}post_in_tags`.`post_id`={2} WHERE `{0}post_in_tags`.`tp_id` = {3};", Helper.Prefix, postInTags.TagID, postInTags.PostID, postInTags.ID);
            return Helper.Query(sql);
        }

        /// <summary>
        /// 删除关系
        /// </summary>
        /// <param name="id">删除 ID</param>
        /// <param name="mode">删除模式</param>
        /// <returns></returns>
        public int Delete(int id, ModifiedMode mode)
        {
            string sql = string.Format("DELETE FROM `{0}post_in_tags` WHERE `{0}post_in_tags`.`{1}_id`={2};", Helper.Prefix, mode == ModifiedMode.Self ? "tp" : mode == ModifiedMode.TagOrCategoriy ? "tag" : "post", id);
            return Helper.Query(sql);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(ModifiedMode mode, params int[] ids)
        {
            string sql = string.Format("DELETE FROM `{0}post_in_tags` WHERE `{0}post_in_tags`.`{1}_id` in ({2});", Helper.Prefix, mode == ModifiedMode.Self ? "tp" : mode == ModifiedMode.TagOrCategoriy ? "tag" : "post", string.Join(",", ids));
            return Helper.Query(sql);
        }

        protected override PostInTagsModel ToModel(DataRow row)
        {
            PostInTagsModel tag = new PostInTagsModel();
            if (row["tp_id"] != null) tag.ID = Convert.ToInt32(row["tp_id"]);
            if (row["tag_id"] != null) tag.TagID = Convert.ToInt32(row["tag_id"]);
            if (row["post_id"] != null) tag.PostID = Convert.ToInt32(row["post_id"]);
            return tag;
        }
    }
}
