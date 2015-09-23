using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class PostOptionsService : BaseService<IPostOptionsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.PostOptionsDAL;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">键ID</param>
        /// <param name="isPostId">是否文章 ID</param>
        /// <returns></returns>
        public int Delete(int id, bool isPostId = false)
        {
            return CurrentDAL.Delete(id, isPostId);
        }
    }
}
