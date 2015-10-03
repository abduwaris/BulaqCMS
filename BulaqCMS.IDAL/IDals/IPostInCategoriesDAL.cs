using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface IPostInCategoriesDAL
    {
        /// <summary>
        /// 获取所有关系
        /// </summary>
        /// <returns></returns>
        List<PostInCategoriesModel> GetList();

        /// <summary>
        /// 根据关系获取集合
        /// </summary>
        /// <param name="id">关系者 ID</param>
        /// <param name="isPostId">根据什么获取,文章还是专辑, 默认就是 文章</param>
        /// <returns></returns>
        List<PostInCategoriesModel> GetList(int id, bool isPostId = true);

        /// <summary>
        /// 想文章添加专辑
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="catIds"></param>
        /// <returns></returns>
        int InsertForPosts(int postId, params int[] catIds);

        /// <summary>
        /// 根据 关系 ID 删除
        /// </summary>
        /// <param name="pc_id"></param>
        /// <returns></returns>
        int Delete(ModifiedMode mode, params int[] pc_id);


        /// <summary>
        /// 根据关系着删除
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="catId">是否是专辑id,文章id</param>
        /// <returns></returns>
        int Delete(int id, bool catId);
    }
}
