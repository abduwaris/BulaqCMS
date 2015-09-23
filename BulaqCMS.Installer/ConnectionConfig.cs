using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.Installer
{
    public class ConnectionConfig
    {
        /// <summary>
        /// Server IP Address or Server Name
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// Mysql Database Name
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Table Prefix
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// User for Mysql
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Password for Mysql User
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// MySql Server Port
        /// </summary>
        public uint Port { get; set; }
    }
}
