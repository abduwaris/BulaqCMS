using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class OptionsService:BaseService<IOptionsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.OptionsDAL;
        }
    }
}
