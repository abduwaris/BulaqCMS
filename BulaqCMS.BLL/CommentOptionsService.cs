using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class CommentOptionsService : BaseService<ICommentOptionsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.CommentOptionsDAL;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isByCommentId"></param>
        /// <returns></returns>
        public int Delete(int id, bool isByCommentId)
        {
            return CurrentDAL.Delete(id, isByCommentId);
        }

        /// <summary>
        /// 根据键集合删除
        /// </summary>
        /// <param name="isByCommentIds"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(bool isByCommentIds, params int[] ids)
        {
            return CurrentDAL.Delete(isByCommentIds, ids);
        }
    }
}
