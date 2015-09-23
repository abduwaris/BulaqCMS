using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.Installer;
using MySql.Data.MySqlClient;
using System.Data;

namespace BulaqCMS.Installer.Mysql
{
    public class MySqlInstaller : IInstallService
    {
        private string _conStr;

        /// <summary>
        /// 链接字符串
        /// </summary>
        public string ConnectionString { get { return _conStr; } }
        /// <summary>
        /// 配置信息,链接成功才能得到,否则得不到返回 null
        /// </summary>
        public ConnectionConfig Config { get; private set; }

        /// <summary>
        /// 是否链接成功
        /// </summary>
        public bool IsConnect { get; private set; }
        /// <summary>
        /// 链接数据库测试,第一要执行的任务
        /// </summary>
        /// <param name="config">配置文件</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns>是否链接成功</returns>
        public bool Connect(ConnectionConfig config, ref string connectionString)
        {
            MySqlConnectionStringBuilder bui = new MySqlConnectionStringBuilder();
            bui.Server = config.Server;
            bui.Database = config.Database;
            bui.UserID = config.User;
            bui.Password = config.Password;
            if (config.Port != 3306) bui.Port = config.Port;
            connectionString = bui.GetConnectionString(!string.IsNullOrEmpty(config.Password));
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    IsConnect = true;
                    Config = config;
                    this._conStr = connectionString;
                }
                catch
                {
                    IsConnect = false;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 链接字符串在配置文件中的键
        /// </summary>
        public string ConnectionStringName
        {
            get { return ""; }
        }
        /// <summary>
        /// 数据库表前缀在配置文件中的键
        /// </summary>
        public string PrefixName
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 获取当前连接所有, 执行前确保当前会话连接成功,才能得到结果
        /// </summary>
        /// <returns>链接失败: null; 没有表: count=0; 得到返回表集合</returns>
        public List<string> GetCreatedTables()
        {
            List<string> list = null;
            if (IsConnect)
            {
                DataTable dt = new DataTable();
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    string sql = string.Format("SHOW TABLES From `{0}`", Config.Database);
                    using (MySqlDataAdapter mda = new MySqlDataAdapter(sql, con))
                    {
                        con.Open();
                        if (con.State == ConnectionState.Open)
                        {
                            mda.Fill(dt);
                        }
                    }
                }
                list = new List<string>();
                //判断是否有数据
                if (dt.Columns.Count > 0)
                {
                    list = dt.Select().Select(row => row[0].ToString()).ToList();
                }
            }
            return list;
        }

        /// <summary>
        /// 开始创建表,请确保当前会话连接成功
        /// </summary>
        /// <returns></returns>
        public bool CreateTables(FirstUserModel user)
        {
            return false;
        }

        private List<string> Sqls()
        {
            List<string> sqls = new List<string>();

            ///Category Table
            string sql = string.Format("DROP TABLE IF EXISTS `{0}categories`;CREATE TABLE `{0}categories` (`cat_id` int(11) NOT NULL AUTO_INCREMENT,`cat_name` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,`cat_title` varchar(255) COLLATE utf8_unicode_ci NOT NULL,`theme_guid` varchar(255) COLLATE utf8_unicode_ci DEFAULT '0',`cat_parent` int(255) DEFAULT '0',`cat_des` text COLLATE utf8_unicode_ci,PRIMARY KEY (`cat_id`)) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;", Config.Prefix);
            sqls.Add(sql);

            ///Comments Table
            sql = string.Format("DROP TABLE IF EXISTS `{0}comments`;CREATE TABLE `{0}comments` (`com_id` int(11) NOT NULL,`post_id` int(11) NOT NULL,`author_id` int(11) DEFAULT '0',`parent_id` int(11) DEFAULT '0',`content` text COLLATE utf8_unicode_ci,`write_time` datetime DEFAULT NULL,`author_ip` varchar(20) COLLATE utf8_unicode_ci DEFAULT NULL,`user_agent` varchar(1024) COLLATE utf8_unicode_ci DEFAULT NULL,`author_name` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,`author_email` varchar(255) COLLATE utf8_unicode_ci,`author_url` varchar(255) COLLATE utf8_unicode_ci DEFAULT '0',`approved` bit(1) NOT NULL,`del_flag` bit(1) DEFAULT b'0',`in_recycle` bit(1) DEFAULT b'0',PRIMARY KEY (`com_id`)) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;", Config.Prefix);

            return null;
        }
    }
}
