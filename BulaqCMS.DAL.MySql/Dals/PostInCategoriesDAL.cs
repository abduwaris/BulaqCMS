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
    public class PostInCategoriesDAL : BaseDAL<PostInCategoriesModel>, IPostInCategoriesDAL
    {
        /// <summary>
        /// 获取所有关系
        /// </summary>
        /// <returns></returns>
        public List<PostInCategoriesModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}post_in_cats`", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据关系获取集合
        /// </summary>
        /// <param name="id">关系者 ID</param>
        /// <param name="isPostId">根据什么获取,文章还是专辑, 默认就是 文章</param>
        /// <returns></returns>
        public List<PostInCategoriesModel> GetList(int id, bool isPostId = true)
        {
            string sql = string.Format("select * from `{0}post_in_cats` where `{0}post_in_cats`.`{1}_id`={2};", Helper.Prefix, isPostId ? "post" : "cat", id);
            return ToModelList(Helper.Select(sql));
        }


        /// <summary>
        /// 想文章添加专辑
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="catIds"></param>
        /// <returns></returns>
        public int InsertForPosts(int postId, params int[] catIds)
        {
            if (catIds == null || catIds.Length <= 0) return 0;
            //INSERT INTO post_in_cats(post_in_cats.cat_id,post_in_cats.post_id) VALUES(2,3),(4,5);
            List<string> vals = new List<string>();
            foreach (var catId in catIds)
                vals.Add(string.Format("({0},{1})", catId, postId));
            string sql = string.Format("INSERT INTO `{0}post_in_cats`(`{0}post_in_cats`.`cat_id`,`{0}post_in_cats`.`post_id`) VALUES{1};", Helper.Prefix, string.Join(",", vals));
            return Helper.Query(sql);
        }

        /// <summary>
        /// 根据 关系 ID 删除
        /// </summary>
        /// <param name="pc_id"></param>
        /// <returns></returns>
        public int Delete(params int[] pc_id)
        {
            if (pc_id == null || pc_id.Length <= 0) return 0;
            string sql = string.Format("DELETE FROM `{0}post_in_cats` WHERE `{0}post_in_cats`.`pc_id` IN ({1});", Helper.Prefix, string.Join(",", pc_id));
            return Helper.Query(sql);
        }

        /// <summary>
        /// 根据关系着删除
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="catId">是否是专辑id,文章id</param>
        /// <returns></returns>
        public int Delete(int id, bool catId)
        {
            string sql = string.Format("DELETE FROM `{0}post_in_cats` WHERE `{0}post_in_cats`.`{1}_id`={2};", Helper.Prefix, catId ? "cat" : "post", id);
            return Helper.Query(sql);
        }

        protected override PostInCategoriesModel ToModel(DataRow row)
        {
            PostInCategoriesModel cat = new PostInCategoriesModel();
            if (row["pc_id"] != null) cat.ID = Convert.ToInt32(row["pc_id"]);
            if (row["cat_id"] != null) cat.CategoryID = Convert.ToInt32(row["cat_id"]);
            if (row["post_id"] != null) cat.PostID = Convert.ToInt32(row["post_id"]);
            return cat;
        }
    }
}
