using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    [Table("User")]
    public class UserModel<T>
    {
        [Column("user_id")]
        public int UserID { get; set; }

        [Column("login_name")]
        public string LoginName { get; set; }

        [Column("password")]
        public string Password { get; set; }

    }
}
