using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.DAL.MySql
{
    /// <summary>
    /// 找不到 Mysql 配置文件
    /// </summary>
    public sealed class MySqlConfigFileException : Exception
    {
        private bool IsExists { get; set; }
        public MySqlConfigFileException(bool isExists) { this.IsExists = isExists; }
    }
}
