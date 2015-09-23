using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.Models;
namespace BulaqCMS.BLL
{
    public class CategoriesService : BaseService<ICategoriesDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.CategoriesDAL;
        }

        public List<CategoriesModel> GetList()
        {
            return CurrentDAL.GetList();
        }
        /// <summary>
        /// 根据获取
        /// </summary>
        /// <param name="readPostsCount">是否读取文章个数</param>
        /// <returns></returns>
        public List<CategoriesModel> GetList(bool readPostsCount)
        {
            var cats = CurrentDAL.GetList();
            if (readPostsCount)
            {
                var pinc = DAL.PostInCategoriesDAL.GetList();
                foreach (var c in cats)
                    c.PostsCount = pinc.Count(p => p.CategoryID == c.ID);
            }
            return cats;
        }

        //public List<CategoriesModel> GetList(params int[] cids)
        //{

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CategoriesModel One(string name)
        {
            return CurrentDAL.One(name);
        }

        public CategoriesModel One(int cid)
        {
            return CurrentDAL.One(cid);
        }

        public bool Add(CategoriesModel cat, List<string> errors)
        {
            var cats = CurrentDAL.GetList();
            //判断名称是否存在
            if (cats.Count(p => p.Name == cat.Name) > 0) errors.Add("has_name");
            //if (cats.Count(p => p.Title == cat.Title) > 0) errors.Add("has_title");
            if (cat.ParentID <= 0) cat.ParentID = 0;
            else if (cats.Count(p => p.ID == cat.ParentID) <= 0) errors.Add("parent_filed");
            //要判断主题是否存在,不存在就是默认
            //if(!string.IsNullOrEmpty(cat.ThemeGuid))
            if (errors.Count <= 0)
            {
                if (string.IsNullOrEmpty(cat.Name)) cat.Name = "g" + Guid.NewGuid().ToString().Replace("-", "");
                if (CurrentDAL.Insert(cat) <= 0) errors.Add("on_add_error");
                else return true;
            }
            return false;
        }

        public bool Update(CategoriesModel cat, List<string> errors)
        {
            var cats = CurrentDAL.GetList().Where(p => p.ID != cat.ID);
            //判断名称是否存在
            if (cats.Count(p => p.Name == cat.Name) > 0) errors.Add("has_name");
            //if (cats.Count(p => p.Title == cat.Title) > 0) errors.Add("has_title");
            if (cat.ParentID <= 0) cat.ParentID = 0;
            else if (cats.Count(p => p.ID == cat.ParentID) <= 0) errors.Add("parent_filed");
            //要判断主题是否存在,不存在就是默认
            //if(!string.IsNullOrEmpty(cat.ThemeGuid))
            if (errors.Count <= 0)
            {
                if (string.IsNullOrEmpty(cat.Name)) cat.Name = "g" + Guid.NewGuid().ToString().Replace("-", "");
                if (CurrentDAL.Update(cat) <= 0) errors.Add("on_update_error");
                else return true;
            }
            return false;
        }

        /// <summary>
        /// 删除专辑
        /// </summary>
        /// <param name="id">要删除的专辑id</param>
        /// <param name="deleteChilds">是否删除子专辑, 如果不删除起给这个专辑的父级</param>
        /// <returns></returns>
        public bool Delete(int id, bool deleteChilds)
        {
            //判断是否有子
            var cat = One(id);
            if (cat == null) return false;
            var chis = CurrentDAL.GetList(id, true);
            if (chis.Count > 0 && deleteChilds)
            {
                foreach (var c in chis)
                    Delete(c.ID, true);
                CurrentDAL.Delete(id, true);
            }
            else if (chis.Count > 0) CurrentDAL.MoveParent(id, cat.ParentID);
            //删除文章专辑关系
            DAL.PostInCategoriesDAL.Delete(id, true);
            //删除自己
            return CurrentDAL.Delete(id, false) > 0;
        }

        /// <summary>
        /// 判断当前的id是否当做pid
        /// </summary>
        /// <param name="id">当前 ID</param>
        /// <param name="pid">PID</param>
        /// <param name="pids">父子关系</param>
        /// <param name="allIds">子:父</param>
        /// <returns></returns>
        private bool CanParent(int id, int pid, List<int> pids, Dictionary<int, int> allIds)
        {
            return true;
        }
    }
}
