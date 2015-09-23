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
    public class TagsDAL : BaseDAL<TagsModel>, ITagsDAL
    {
        /// <summary>
        /// 获取所有的标签
        /// </summary>
        /// <returns></returns>
        public List<TagsModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}tags`", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据id集合或标签
        /// </summary>
        /// <param name="ids">id 集合</param>
        /// <returns></returns>
        public List<TagsModel> GetList(params int[] ids)
        {
            if (ids == null || ids.Length <= 10) return GetList();
            string sql = string.Format("SELECT * FROM `{0}tags` WHERE `{0}tags`.`tag_id` IN ({1});", Helper.Prefix, string.Join(",", ids));
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据文章获取标签集合
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public List<TagsModel> GetListByPost(int postId)
        {
            string sql = string.Format("select `{0}tags`.* from `{0}post_in_tags` LEFT JOIN `{0}tags` on `{0}tags`.`tag_id`=`{0}post_in_tags`.`tag_id` where `{0}post_in_tags`.`post_id`={1};", Helper.Prefix, postId);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据 Title 索索
        /// </summary>
        /// <param name="titleLike">title 或者 Name</param>
        /// <param name="isName">是否名字像</param>
        /// <returns></returns>
        public List<TagsModel> Search(string titleLike, bool isName = false)
        {
            string sql = string.Format("SELECT * FROM `{0}tags` WHERE `{0}tags`.`{1}` LIKE @like;", Helper.Prefix,isName?"name":"title");
            return ToModelList(Helper.Select(sql, new MySqlParameter("@like", titleLike)));
        }



        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tag">要新增的标签</param>
        /// <returns></returns>
        public int Insert(TagsModel tag)
        {
            string sql = string.Format("INSERT `{0}tags`(`{0}tags`.`title`,`{0}tags`.`name`,`{0}tags`.`des`) VALUES(@title,@name,@des)", Helper.Prefix);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@title",tag.Title),
                                     new MySqlParameter("@name",tag.Name),
                                     new MySqlParameter("@des",tag.Des)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="tag">要修改的标签</param>
        /// <returns></returns>
        public int Update(TagsModel tag)
        {
            string sql = string.Format("UPDATE `{0}tags` SET `{0}tags`.`title`,`{0}tags`.`name`,`{0}tags`.`des` WHERE `{0}tags`.`tag_id` = {1}", Helper.Prefix, tag.ID);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@title",tag.Title),
                                     new MySqlParameter("@name",tag.Name),
                                     new MySqlParameter("@des",tag.Des)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="ids">标签id集合</param>
        /// <returns></returns>
        public int Delete(params int[] ids)
        {
            if (ids == null || ids.Length <= 0) return -1;
            string sql = string.Format("DELETE FROM `{0}tags` WHERE `{0}tags`.`tag_id` IN ({1})", Helper.Prefix, string.Join(",", ids));
            return Helper.Query(sql);
        }

        protected override TagsModel ToModel(DataRow row)
        {
            TagsModel tag = new TagsModel();
            if (row["tag_id"] != null) tag.ID = Convert.ToInt32(row["tag_id"]);
            if (row["title"] != null) tag.Title = row["title"].ToString();
            if (row["name"] != null) tag.Name = row["name"].ToString();
            if (row["des"] != null) tag.Des = row["des"].ToString();
            return tag;
        }
    }
}
