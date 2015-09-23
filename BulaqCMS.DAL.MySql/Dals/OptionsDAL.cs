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
    public class OptionsDAL : BaseDAL<OptionsModel>, IOptionsDAL
    {
        /// <summary>
        /// 获取所有Option
        /// </summary>
        /// <returns></returns>
        public List<OptionsModel> GetList()
        {
            string sql = string.Format("SELECT * FROM `{0}options`;", Helper.Prefix);
            return ToModelList(Helper.Select(sql));
        }

        /// <summary>
        /// 新增系统参数
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public int Insert(OptionsModel option)
        {
            string sql = string.Format("INSERT `{0}options`(`{0}options`.`option_key`, `{0}options`.`option_value`) VALUES(@key, @val)", Helper.Prefix);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 修改参数
        /// </summary>
        /// <param name="option">要修改的参数</param>
        /// <returns></returns>
        public int Update(OptionsModel option)
        {
            string sql = string.Format("UpDATE `{0}options` SET `{0}options`.`option_key`=@key, `{0}options`.`option_value`=@val WHERE `{0}options`.`option_id`={1}", Helper.Prefix, option.ID);
            MySqlParameter[] param = { 
                                     new MySqlParameter("@key",option.Key),
                                     new MySqlParameter("@val",option.Value)
                                     };
            return Helper.Query(sql, param);
        }

        /// <summary>
        /// 删除制定的 Option
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = string.Format("DELETE FROM `{0}options` WHERE `{0}options`.`option_id`={1};", Helper.Prefix, id);
            return Helper.Query(sql);
        }


        protected override OptionsModel ToModel(DataRow row)
        {
            OptionsModel op = new OptionsModel();
            if (row["option_id"] != null) op.ID = Convert.ToInt32(row["option_id"]);
            if (row["option_key"] != null) op.Key = row["option_key"].ToString();
            if (row["option_value"] != null) op.Key = row["option_value"].ToString();
            return op;
        }
    }
}
