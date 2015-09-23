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
    public class CategoriesDAL : BaseDAL<CategoriesModel>, ICategoriesDAL
    {
        /// <summary>
        /// 获取所有专辑
        /// </summary>
        /// <returns></returns>
        public List<CategoriesModel> GetList()
        {
            string sql = string.Format("select * from `{0}categories`;", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 获取一堆
        /// </summary>
        /// <param name="id">条件 ID</param>
        /// <param name="isParentId">是不是跟父查找</param>
        /// <returns></returns>
        public List<CategoriesModel> GetList(int id, bool isParentId)
        {
            string sql = string.Format("select * from `{0}categories` where `{0}categories`.`{1}`={2};", Helper.Prefix, isParentId ? "cat_parent" : "cat_id", id);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据文章查找
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public List<CategoriesModel> GetList(int postId)
        {
            string sql = string.Format("SELECT `{0}categories`.* from `{0}post_in_cats` LEFT JOIN `{0}categories` on `{0}post_in_cats`.`cat_id`=`{0}categories`.`cat_id` where `{0}post_in_cats`.`post_id`={1}", Helper.Prefix, postId);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据别名获取专辑
        /// </summary>
        /// <param name="name">别名</param>
        /// <returns></returns>
        public CategoriesModel One(string name)
        {
            string sql = string.Format("Select * from `{0}categories` where `{0}categories`.`cat_name`=@name;", Helper.Prefix);
            return ToModelList(Helper.Select(sql, new MySqlParameter("@name", name))).FirstOrDefault();
        }

        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public CategoriesModel One(int catId)
        {
            return GetList(catId, false).FirstOrDefault();
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="cat">对象</param>
        /// <returns></returns>
        public int Insert(CategoriesModel cat)
        {
            string sql = string.Format("insert `{0}categories`(`{0}categories`.`cat_name`, `{0}categories`.`cat_title`, `{0}categories`.`theme_guid`, `{0}categories`.`cat_parent`, `{0}categories`.`cat_des`) values(@cat_name, @cat_title, @theme_guid, @cat_parent, @cat_des);", Helper.Prefix);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@cat_name",cat.Name),
                                     new MySqlParameter("@cat_title",cat.Title),
                                     new MySqlParameter("@theme_guid",cat.ThemeGuid),
                                     new MySqlParameter("@cat_parent",cat.ParentID),
                                     new MySqlParameter("@cat_des",cat.Des)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        public int Update(CategoriesModel cat)
        {
            string sql = string.Format("update `{0}categories` set `{0}categories`.`cat_name`=@cat_name, `{0}categories`.`cat_title`=@cat_title, `{0}categories`.`theme_guid`=@theme_guid, `{0}categories`.`cat_parent`=@cat_parent, `{0}categories`.`cat_des`=@cat_des where `{0}categories`.`cat_id`={1};", Helper.Prefix, cat.ID);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@cat_name",cat.Name),
                                     new MySqlParameter("@cat_title",cat.Title),
                                     new MySqlParameter("@theme_guid",cat.ThemeGuid),
                                     new MySqlParameter("@cat_parent",cat.ParentID),
                                     new MySqlParameter("@cat_des",cat.Des)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除 ID</param>
        /// <param name="isParentId">是否根据父删除</param>
        /// <returns></returns>
        public int Delete(int id, bool isParentId)
        {
            string sql = string.Format("Delete from `{0}categories` where `{0}categories`.`{2}`={1};", Helper.Prefix, id, isParentId ? "cat_parent" : "cat_id");
            return Helper.Query(sql);
        }

        /// <summary>
        /// 父子修改
        /// </summary>
        /// <param name="oldParentId">久父</param>
        /// <param name="newParentId">新父</param>
        /// <returns></returns>
        public int MoveParent(int oldParentId, int newParentId)
        {
            string sql = string.Format("UPDATE `{0}categories` SET `{0}categories`.`cat_parent`={1} WHERE `{0}categories`.`cat_parent`={2};", Helper.Prefix, newParentId, oldParentId);
            return Helper.Query(sql);
        }

        protected override CategoriesModel ToModel(DataRow row)
        {
            CategoriesModel cat = new CategoriesModel();
            if (row["cat_id"] != null) cat.ID = Convert.ToInt32(row["cat_id"]);
            if (row["cat_parent"] != null) cat.ParentID = Convert.ToInt32(row["cat_parent"]);
            if (row["cat_name"] != null) cat.Name = row["cat_name"].ToString();
            if (row["cat_title"] != null) cat.Title = row["cat_title"].ToString();
            if (row["theme_guid"] != null) cat.ThemeGuid = row["theme_guid"].ToString();
            if (row["cat_des"] != null) cat.Des = row["cat_des"].ToString();
            return cat;
        }
    }
}
