using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class NavsService:BaseService<INavsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.NavsDAL;
        }
    }
}
