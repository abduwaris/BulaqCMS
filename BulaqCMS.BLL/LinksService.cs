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

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public bool Add(LinksModel link)
        {
            return CurrentDAL.Insert(link) > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public bool Update(LinksModel link)
        {
            return CurrentDAL.Update(link) > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="linkId"></param>
        /// <returns></returns>
        public bool Delete(int linkId)
        {
            return CurrentDAL.Delete(linkId) > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public bool Delete(LinksModel link)
        {
            return Delete(link.ID);
        }
    }
}
