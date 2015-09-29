using BulaqCMS.IDAL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class NavsService : BaseService<INavsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.NavsDAL;
        }


        public List<NavsModel> GetList()
        {
            return CurrentDAL.GetList();
        }

        /// <summary>
        /// 根据菜单分类获取菜单
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<NavsModel> NavsByGroupId(int groupId)
        {
            if (groupId <= 0) return new List<NavsModel>();
            return CurrentDAL.NavsByGroupId(groupId);
        }

        public bool Add(NavsModel nav)
        {
            if (nav == null) return false;
            return CurrentDAL.Insert(nav) > 0;
        }

        /// <summary>
        /// 修改菜单顺序
        /// </summary>
        /// <param name="navId"></param>
        /// <param name="newIndex"></param>
        /// <returns></returns>
        public bool UpdateIndex(int navId, short newIndex)
        {
            if (navId <= 0 || newIndex <= 0) return false;
            return CurrentDAL.NewIndex(navId, newIndex) > 0;
        }

        public bool UpdateParent(int navId, int newParentId)
        {
            if (navId <= 0 || newParentId <= 0) return false;
            return CurrentDAL.NewParent(navId, newParentId) > 0;
        }

        public bool Update(NavsModel nav)
        {
            if (nav == null) return false;
            return CurrentDAL.Update(nav) > 0;
        }

        public bool Delete(int navId)
        {
            if (navId <= 0) return false;
            return CurrentDAL.Delete(navId) > 0;
        }

        ///// <summary>
        ///// 集合删除
        ///// </summary>
        ///// <param name="groupIds"></param>
        ///// <returns></returns>
        //public bool Delete(params int[] navIds)
        //{
        //    if (navIds == null || navIds.Length < 0) return false;
        //}

        public bool DeleteByGroup(int groupId)
        {

        }
    }
}
