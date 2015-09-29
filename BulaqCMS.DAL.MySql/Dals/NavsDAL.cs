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
    public class NavsDAL : BaseDAL<NavsModel>, INavsDAL
    {
        /// <summary>
        /// 获取所有菜单
        /// </summary>
        /// <returns></returns>
        public List<NavsModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}navs`;", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据菜单分类获取菜单
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<NavsModel> NavsByGroupId(int groupId)
        {
            string sql = string.Format("SELECT * FROM `{0}navs` where `{0}navs`.`group_id`={1};", Helper.Prefix, groupId);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 根据分组获取
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<NavsModel> GetList(int groupId)
        {
            string sql = string.Format("SELECT * FROM `{0}navs` WHERE `{0}navs`.`group_id`={1};", Helper.Prefix, groupId);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="nav"></param>
        /// <returns></returns>
        public int Insert(NavsModel nav)
        {
            string sql = string.Format("INSERT `{0}navs`(`{0}navs`.`group_id`, `{0}navs`.`parent_id`, `{0}navs`.`index`, `{0}navs`.`title`, `{0}navs`.`url`, `{0}navs`.`image`, `{0}navs`.`target`, `{0}navs`.`visible`, `{0}navs`.`des`, `{0}navs`.`from`) VALUES(@group_id, @parent_id, @index, @title, @url, @image, @target, @visible, @des, @from);", Helper.Prefix);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@group_id",nav.GroupID),
                                     new MySqlParameter("@parent_id",nav.ParentID),
                                     new MySqlParameter("@index",nav.Index),
                                     new MySqlParameter("@title",nav.Title),
                                     new MySqlParameter("@url",nav.Url),
                                     new MySqlParameter("@image",nav.Image),
                                     new MySqlParameter("@target",nav.Target),
                                     new MySqlParameter("@visible",nav.Visible),
                                     new MySqlParameter("@des",nav.Des),
                                     new MySqlParameter("@from",nav.From)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="nav">要修改的对象</param>
        /// <returns></returns>
        public int Update(NavsModel nav)
        {
            string sql = string.Format("UPDATE `{0}navs` SET `{0}navs`.`group_id`=@group_id, `{0}navs`.`parent_id`=@parent_id, `{0}navs`.`index`=@index, `{0}navs`.`title`=@title, `{0}navs`.`url`=@url, `{0}navs`.`image`=@image, `{0}navs`.`target`=@target, `{0}navs`.`visible`=@visible, `{0}navs`.`des`=@des, `{0}navs`.`from`=@from WHERE `{0}navs`.`nav_id`={1};", Helper.Prefix, nav.ID);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@group_id",nav.GroupID),
                                     new MySqlParameter("@parent_id",nav.ParentID),
                                     new MySqlParameter("@index",nav.Index),
                                     new MySqlParameter("@title",nav.Title),
                                     new MySqlParameter("@url",nav.Url),
                                     new MySqlParameter("@image",nav.Image),
                                     new MySqlParameter("@target",nav.Target),
                                     new MySqlParameter("@visible",nav.Visible),
                                     new MySqlParameter("@des",nav.Des),
                                     new MySqlParameter("@from",nav.From)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 新的顺序
        /// </summary>
        /// <param name="navId"></param>
        /// <param name="newIndex"></param>
        /// <returns></returns>
        public int NewIndex(int navId, short newIndex)
        {
            string sql = string.Format("update `{0}navs` set `{0}navs`.`index`={1} where `{0}navs`.`nav_id`={2};", Helper.Prefix, newIndex, navId);
            return Helper.Query(sql);
        }

        /// <summary>
        /// 修改父级
        /// </summary>
        /// <param name="navId"></param>
        /// <param name="newParentId"></param>
        /// <returns></returns>
        public int NewParent(int navId, int newParentId)
        {
            string sql = string.Format("update `{0}navs` set `{0}navs`.`parent_id`={1} where `{0}navs`.`nav_id`={2};", Helper.Prefix, newParentId, navId);
            return Helper.Query(sql);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除的ID</param>
        /// <returns></returns>
        public int Delete(int id, bool isGroupId = false)
        {
            string sql = string.Format("DELETE FROM `{0}navs` WHERE `{0}navs`.`{2}_id`={1};", Helper.Prefix, id, isGroupId ? "group" : "nav");
            return Helper.Query(sql);
        }

        protected override NavsModel ToModel(DataRow row)
        {
            NavsModel nav = new NavsModel();
            if (row["nav_id"] != null) nav.ID = Convert.ToInt32(row["nav_id"]);
            if (row["group_id"] != null) nav.GroupID = Convert.ToInt32(row["group_id"]);
            if (row["parent_id"] != null) nav.ParentID = Convert.ToInt32(row["parent_id"]);
            if (row["index"] != null) nav.Index = Convert.ToInt16(row["index"]);
            if (row["target"] != null) nav.Target = Convert.ToInt16(row["target"]);
            if (row["from"] != null) nav.From = Convert.ToInt16(row["from"]);
            if (row["visible"] != null) nav.Visible = Convert.ToBoolean(row["visible"]);
            if (row["title"] != null) nav.Title = row["title"].ToString();
            if (row["url"] != null) nav.Url = row["url"].ToString();
            if (row["image"] != null) nav.Image = row["image"].ToString();
            if (row["des"] != null) nav.Des = row["des"].ToString();
            return nav;
        }
    }
}
