using BulaqCMS.IDAL;
using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.BLL
{
    public class TagsService : BaseService<ITagsDAL>
    {
        protected override void SetCurrentDAL()
        {
            this.CurrentDAL = DAL.TagsDAL;
        }

        /// <summary>
        /// 是否引入文章数量
        /// </summary>
        /// <param name="includePostsCount"></param>
        /// <returns></returns>
        public List<TagsModel> GetList(bool includePostsCount = false)
        {
            var tags = CurrentDAL.GetList();
            if (includePostsCount && tags.Count > 0)
            {
                var pintags = DAL.PostInTagsDAL.GetList(ModifiedMode.TagOrCategoriy, tags.Select(p => p.ID).ToArray());
                foreach (var tag in tags)
                    tag.PostsCount = pintags.Count(p => p.TagID == tag.ID);
            }
            return tags;
        }

        /// <summary>
        /// 根据文章获取标签
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public List<TagsModel> GetTagsByPostId(int postId)
        {
            return CurrentDAL.GetListByPost(postId);
        }

        public TagsModel GetTags(int tagId)
        {
            return CurrentDAL.GetList(tagId).FirstOrDefault();
        }

        /// <summary>
        /// 掺入标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool Add(TagsModel tag)
        {
            return CurrentDAL.Insert(tag) > 0;
        }

        /// <summary>
        /// 新增一个标签
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public bool Add(TagsModel tag, List<string> errors)
        {
            //判断是否用title
            var hasTag = CurrentDAL.Search(tag.Title);
            if (hasTag != null && hasTag.Count() > 0)
            {
                errors.Add("has_title");
                return false;
            }
            //不存在
            hasTag = CurrentDAL.Search(tag.Name, true);
            if (hasTag != null && hasTag.Count > 0)
            {
                errors.Add("has_name");
                return false;
            }
            //添加
            if (CurrentDAL.Insert(tag) > 0)
            {
                //获取
                var newTag = CurrentDAL.Search(tag.Title).FirstOrDefault();
                tag.ID = newTag.ID;
                return true;
            }
            errors.Add("add_tag_error");
            return false;
        }

        /// <summary>
        /// 快速新增标签
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool QuickAdd(TagsModel tag)
        {
            //判断是否存在
            var hasTag = CurrentDAL.Search(tag.Title);
            if (hasTag.Count() > 0)
            {
                tag.ID = hasTag.First().ID;
                tag.Name = hasTag.First().Name;
                tag.Des = hasTag.First().Des;
                return true;
            }
            //新增
            tag.Name = Guid.NewGuid().ToString().Replace("-", "");
            tag.Des = "";
            if (CurrentDAL.Insert(tag) > 0)
            {
                tag.ID = CurrentDAL.Search(tag.Title).First().ID;
                return true;
            }
            return false;

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public bool Update(TagsModel tag)
        {
            return CurrentDAL.Update(tag) > 0;
        }

        public bool Update(TagsModel tag, List<string> errors)
        {
            //判断是否用title
            var hasTag = CurrentDAL.Search(tag.Title);
            if (hasTag != null && hasTag.Count(p => p.ID != tag.ID) > 0) errors.Add("has_title");
            else
            {
                //不存在
                hasTag = CurrentDAL.Search(tag.Name, true);
                if (hasTag != null && hasTag.Count(p => p.ID != tag.ID) > 0) errors.Add("has_name");
                else if (CurrentDAL.Update(tag) > 0) return true;
                errors.Add("on_update_error");
            }
            return false;
        }

        public bool Delete(int tagId)
        {
            //删除文章关系
            Service.PostInTagsService.Delete(tagId, ModifiedMode.TagOrCategoriy);
            //删除自己
            return CurrentDAL.Delete(tagId) > 0;
        }
    }
}
