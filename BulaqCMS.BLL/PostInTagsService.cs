using BulaqCMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulaqCMS.Models;

namespace BulaqCMS.BLL
{
    public class PostInTagsService : BaseService<IPostInTagsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.PostInTagsDAL;
        }

        /// <summary>
        /// 根据关系删除
        /// </summary>
        /// <param name="id">键 Id</param>
        /// <param name="mode">删除模式</param>
        /// <returns></returns>
        public int Delete(int id, ModifiedMode mode)
        {
            return CurrentDAL.Delete(id, mode);
        }

        /// <summary>
        /// 向文章批量插入标签
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public bool Add(int postId, List<TagsModel> tags)
        {
            var hasPostsTags = CurrentDAL.GetList(postId, ModifiedMode.Post);
            //移除已添加的
            var canInsert = tags.Where(p => !hasPostsTags.Select(n => n.TagID).Contains(p.ID));
            if (canInsert.Count() <= 0) return true;

            //批量插入
            if (CurrentDAL.Insert(canInsert.Select(p => new PostInTagsModel() { PostID = postId, TagID = p.ID }).ToArray()) > 0)
            {
                //获取所有
                hasPostsTags = CurrentDAL.GetList(postId, ModifiedMode.Post);
                //不偶去标签集合
                //var tags2 = DAL.TagsDAL.GetList()
            }
            return false;
        }
    }
}
