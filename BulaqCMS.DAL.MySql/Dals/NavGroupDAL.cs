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
    public class NavGroupDAL : BaseDAL<NavGroupModel>, INavGroupDAL
    {
        /// <summary>
        /// 获取所有菜单分类
        /// </summary>
        /// <returns></returns>
        public List<NavGroupModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}nav_group`;", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public int Insert(NavGroupModel group)
        {
            string sql = string.Format("INSERT `{0}nav_group`(`{0}nav_group`.`name`, `{0}nav_group`.`title`, `{0}nav_group`.`des`) VALUES(@name,@title,@des);");
            MySqlParameter[] param = { 
                                     new MySqlParameter("@name",group.Name),
                                     new MySqlParameter("@title",group.Title),
                                     new MySqlParameter("@des",group.Des)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public int Update(NavGroupModel group)
        {
            string sql = string.Format("UPDATE `{0}nav_group` SET `{0}nav_group`.`name`= @name, `{0}nav_group`.`title`= @title, `{0}nav_group`.`des`= @des WHERE `{0}nav_group`.`group_id` = {1};", Helper.Prefix, group.ID);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@name",group.Name),
                                     new MySqlParameter("@title",group.Title),
                                     new MySqlParameter("@des",group.Des)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = string.Format("DELETE FROM `{0}nav_group` WHERE `{0}nav_group`.`group_id` = {1};", Helper.Prefix, id);
            return Helper.Query(sql);
        }

        protected override NavGroupModel ToModel(DataRow row)
        {
            NavGroupModel g = new NavGroupModel();
            if (row["group_id"] != null) g.ID = Convert.ToInt32(row["group_id"]);
            if (row["name"] != null) g.Name = row["name"].ToString();
            if (row["title"] != null) g.Title = row["name"].ToString();
            if (row["des"] != null) g.Des = row["des"].ToString();
            return g;
        }
    }
}
