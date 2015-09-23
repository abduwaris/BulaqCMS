using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class NavGroupService:BaseService<INavGroupDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.NavGroupDAL;
        }
    }
}
