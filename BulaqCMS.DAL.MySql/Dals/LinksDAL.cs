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
    public class LinksDAL : BaseDAL<LinksModel>, ILinksDAL
    {
        /// <summary>
        /// 获取所有连接
        /// </summary>
        /// <returns></returns>
        public List<LinksModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}links`;", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 新增连接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public int Insert(LinksModel link)
        {
            string sql = string.Format("INSERT `{0}links`(`{0}links`.`name`, `{0}links`.`title`, `{0}links`.`url`, `{0}links`.`index`, `{0}links`.`image`, `{0}links`.`des`, `{0}links`.`target`, `{0}links`.`visible`) VALUES(@name, @title, @url, @index, @image, @des, @target, @visible);",Helper.Prefix);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@name",link.Name),
                                     new MySqlParameter("@title",link.Title),
                                     new MySqlParameter("@url",link.Url),
                                     new MySqlParameter("@index",link.Index),
                                     new MySqlParameter("@image",link.Image),
                                     new MySqlParameter("@des",link.Des),
                                     new MySqlParameter("@target",link.Target),
                                     new MySqlParameter("@visible",link.Visible)
                                     };
            return Helper.Query(sql, param);

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public int Update(LinksModel link)
        {
            string sql = string.Format("UPDATE `{0}links` SET `{0}links`.`name`=@name, `{0}links`.`title`=@title, `{0}links`.`url`=@url, `{0}links`.`index`=@index, `{0}links`.`image`=@image, `{0}links`.`des`=@des, `{0}links`.`target`=@target, `{0}links`.`visible`=@visible WHERE `{0}links`.`link_id` = {1};", Helper.Prefix, link.ID);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@name",link.Name),
                                     new MySqlParameter("@title",link.Title),
                                     new MySqlParameter("@url",link.Url),
                                     new MySqlParameter("@index",link.Index),
                                     new MySqlParameter("@image",link.Image),
                                     new MySqlParameter("@des",link.Des),
                                     new MySqlParameter("@target",link.Target),
                                     new MySqlParameter("@visible",link.Visible)
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
            string sql = string.Format("DELETE FROM `{0}links` WHERE `{0}links`.`link_id`={1}", Helper.Prefix, id);
            return Helper.Query(sql);
        }

        protected override LinksModel ToModel(DataRow row)
        {
            LinksModel link = new LinksModel();
            if (row["link_id"] != null) link.ID = Convert.ToInt32(row["link_id"]);
            if (row["index"] != null) link.Index = Convert.ToInt16(row["index"]);
            if (row["target"] != null) link.Target = Convert.ToInt16(row["target"]);
            if (row["visible"] != null) link.Visible = Convert.ToBoolean(row["visible"]);
            if (row["name"] != null) link.Name = row["name"].ToString();
            if (row["title"] != null) link.Title = row["title"].ToString();
            if (row["url"] != null) link.Url = row["url"].ToString();
            if (row["image"] != null) link.Image = row["image"].ToString();
            if (row["des"] != null) link.Des = row["des"].ToString();
            return link;
        }
    }
}
