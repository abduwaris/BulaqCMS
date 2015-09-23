using BulaqCMS.IDAL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class UserOptionsService : BaseService<IUserOptionsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.UserOptionsDAL;
        }
    }
}
