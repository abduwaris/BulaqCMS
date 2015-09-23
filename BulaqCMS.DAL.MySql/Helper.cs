using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace BulaqCMS.DAL.MySql
{
    internal class Helper
    {
        /// <summary>
        /// 获取链接字符串
        /// </summary>
        /// <returns></returns>
        static void CreateConnectionString()
        {
            //获取配置文件
            string configFile = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\App_Data\\mysql.json";
            if (!File.Exists(configFile)) throw new MySqlConfigFileException(false);
            string configTxt = File.ReadAllText(configFile, Encoding.UTF8);
            try
            {
                ConnectionConfig config = JsonConvert.DeserializeObject<ConnectionConfig>(configTxt);
                MySqlConnectionStringBuilder msb = new MySqlConnectionStringBuilder()
                {
                    Server = config.Server,
                    Database = config.Database,
                    UserID = config.User,
                    Password = config.Password,
                    Port = config.Port,
                };
                config.Prefix = config.Prefix == null ? "" : config.Prefix.Trim();
                string str = msb.GetConnectionString(config.Password != null && config.Password != "");
            }
            catch
            {
                throw new MySqlConfigFileException(true);
            }

        }

        /// <summary>
        /// 表前缀
        /// </summary>
        public static string Prefix = ConfigurationManager.ConnectionStrings["MysqlTablesPrefix"].ConnectionString ?? "";

        /// <summary>
        /// 链接字符串配置参数
        /// </summary>
        public static ConnectionConfig Config { get; private set; }

        static readonly string _constr = ConfigurationManager.ConnectionStrings["MysqlConnectionString"].ConnectionString;
        /// <summary>
        /// 链接字符串
        /// </summary>
        static string connectionString = ConfigurationManager.ConnectionStrings["MysqlConnectionString"].ConnectionString;

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="sql">Sql</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static DataTable Select(string sql, params MySqlParameter[] param)
        {
            DataTable dt = new DataTable();
            using (MySqlDataAdapter sda = new MySqlDataAdapter(sql, connectionString))
            {
                if (param != null) sda.SelectCommand.Parameters.AddRange(param);
                sda.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Select 首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static object First(string sql, params MySqlParameter[] param)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    try
                    {
                        if (param != null) cmd.Parameters.AddRange(param);
                        if (con.State != ConnectionState.Open) con.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Insert, Update, Delete
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int Query(string sql, params MySqlParameter[] param)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    if (param != null) cmd.Parameters.AddRange(param);
                    if (con.State != ConnectionState.Open) con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 创建插入 命令
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static string CreateInsertSql(string tableName, string[] values, params string[] columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("INSERT `{0}{1}`", Prefix, tableName));
            if (columns != null && columns.Length > 0)
            {
                sb.Append(" (");
                for (int i = 0; i < columns.Length; i++)
                    sb.Append(string.Format("`{0}{1}`.`{2}`{3}", Prefix, tableName, columns[i], i == columns.Length - 1 ? "" : ","));
                sb.Append(")");
            }
            sb.Append(" VALUES(");
            for (int i = 0; i < values.Length; i++)
                sb.Append(values[i] + (i == values.Length - 1 ? "" : ","));
            sb.Append(");");
            return sb.ToString();
        }

        /// <summary>
        /// 创建所有查找
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static string CreateSelectListSql(string tableName, params string[] columns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            if (columns == null || columns.Length <= 0) sb.Append("*");
            else
                for (int i = 0; i < columns.Length; i++)
                    sb.Append(string.Format("`{0}{1}`.`{2}`{3}", Helper.Prefix, tableName, columns[i], i == columns.Length - 1 ? "" : ","));
            sb.Append(string.Format(" FROM `{0}{1}`", Helper.Prefix, tableName));
            return sb.ToString();
        }
    }
}
