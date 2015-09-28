using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.Models;

namespace BulaqCMS.BLL
{
    public class NavGroupService : BaseService<INavGroupDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.NavGroupDAL;
        }

        public NavGroupModel GetGroupByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            return CurrentDAL.GetGroupByName(name);
        }

        public List<NavGroupModel> GetList()
        {
            return CurrentDAL.GetList();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="navGroup"></param>
        /// <returns></returns>
        public bool Add(NavGroupModel navGroup)
        {
            if (navGroup == null) return false;
            return CurrentDAL.Insert(navGroup) > 0;
        }
    }
}
