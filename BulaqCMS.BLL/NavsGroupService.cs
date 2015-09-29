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


        public List<NavGroupModel> GetList(bool includeNavsCount = false, bool includeNavs = false)
        {
            var navGroups = CurrentDAL.GetList();
            if (includeNavs || includeNavsCount)
            {
                var navs = Service.NavsService.GetList();
                if (includeNavsCount) navGroups.ForEach(group => { group.NavsCount = navs.Count(p => p.GroupID == group.ID); });
                if (includeNavs) navGroups.ForEach(group => { group.Navs = navs.Where(p => p.GroupID == group.ID).ToList(); });
            }
            return navGroups;
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

        public bool Update(NavGroupModel navGroup)
        {
            if (navGroup == null || navGroup.ID <= 0) return false;
            return CurrentDAL.Update(navGroup) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public bool Delete(int groupId)
        {
            //删除
            DAL.NavsDAL.Delete(groupId, true);

            return CurrentDAL.Delete(groupId) > 0;
        }
    }
}
