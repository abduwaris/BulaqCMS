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
    public class ThemeOptionsDAL : BaseDAL<ThemeOptionsModel>, IThemeOptionsDAL
    {
        /// <summary>
        /// 获取摸个主题的某些参数
        /// </summary>
        /// <param name="guid">根据主题标识符获取参数,null:获取所有</param>
        /// <returns></returns>
        public List<ThemeOptionsModel> GetList(string guid)
        {
            string sql = string.Format("SELECT * FROM `{0}theme_options`{1}", Helper.Prefix, string.IsNullOrEmpty(guid) ? "" : string.Format(" WHERE `{0}theme_options`.`guid` = @guid"));
            MySqlParameter par = new MySqlParameter("@guid", guid);
            return ToModelList(Helper.Select(sql, string.IsNullOrEmpty(guid) ? null : par));
        }

        /// <summary>
        /// 添加新的 Options
        /// </summary>
        /// <param name="option">要添加的对象</param>
        /// <returns></returns>
        public int Insert(ThemeOptionsModel option)
        {
            string sql = string.Format("INSERT `{0}theme_options` (`{0}theme_options`.`guid`,`{0}theme_options`.`option_key`,`{0}theme_options`.`option_value`) VALUES(@guid,@key,@val)", Helper.Prefix);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@guid",option.Guid),
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="option">要修改 Option</param>
        /// <returns></returns>
        public int Update(ThemeOptionsModel option)
        {
            string sql = string.Format("UPDATE `{0}theme_options` SET `{0}theme_options`.`guid`=@guid,`{0}theme_options`.`option_key`=@key,`{0}theme_options`.`option_value`=@val WHERE `{0}theme_options`.`option_id`={1}", Helper.Prefix, option.ID);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@guid",option.Guid),
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 根据 ID 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = string.Format("DELETE FROM `{0}theme_options` WHERE `{0}theme_options`.`option_id`={1};", Helper.Prefix, id);
            return Helper.Query(sql);
        }

        /// <summary>
        /// 根据主题删除
        /// </summary>
        /// <param name="guid">主题标识符</param>
        /// <returns></returns>
        public int Delete(string guid)
        {
            string sql = string.Format("DELETE FROM `{0}theme_options` WHERE `{0}theme_options`.`guid`=@guid;", Helper.Prefix);
            return Helper.Query(sql, new MySqlParameter("@guid", guid));
        }

        protected override ThemeOptionsModel ToModel(DataRow row)
        {
            ThemeOptionsModel op = new ThemeOptionsModel();
            if (row["option_id"] != null) op.ID = Convert.ToInt32(row["option_id"]);
            if (row["guid"] != null) op.Guid = row["guid"].ToString();
            if (row["option_key"] != null) op.Key = row["option_key"].ToString();
            if (row["option_value"] != null) op.Value = row["option_value"].ToString();
            return op;
        }
    }
}
