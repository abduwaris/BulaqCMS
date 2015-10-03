using BulaqCMS.IDAL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class PostInCategoriesService : BaseService<IPostInCategoriesDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.PostInCategoriesDAL;
        }

        public List<PostInCategoriesModel> GetList(int id, bool isPostId)
        {
            return CurrentDAL.GetList(id, isPostId);
        }

        /// <summary>
        /// 根据ID集合删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(ModifiedMode mode, params int[] ids)
        {
            return CurrentDAL.Delete(mode, ids);
        }

        /// <summary>
        /// 根据关系删除
        /// </summary>
        /// <param name="id">键 ID</param>
        /// <param name="isCatId">分类还是文章  true:专辑  false:文章</param>
        /// <returns></returns>
        public int Delete(int id, bool isCatId)
        {
            return CurrentDAL.Delete(id, isCatId);
        }

        /// <summary>
        /// 想文章添加专辑
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="catIds"></param>
        /// <returns></returns>
        public int AddForPost(int postId, params int[] catIds)
        {
            return CurrentDAL.InsertForPosts(postId, catIds);
        }
    }
}
