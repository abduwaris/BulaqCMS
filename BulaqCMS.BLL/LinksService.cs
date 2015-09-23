using BulaqCMS.IDAL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class LinksService : BaseService<ILinksDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.LinksDAL;
        }

        public List<LinksModel> GetList()
        {
            return CurrentDAL.GetList();
        }
    }
}
