using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class ThemeOptionsService : BaseService<IThemeOptionsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.ThemeOptionsDAL;
        }
    }
}
