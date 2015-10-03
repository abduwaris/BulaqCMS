using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface ITagsDAL
    {
        /// <summary>
        /// 获取所有的标签
        /// </summary>
        /// <returns></returns>
        List<TagsModel> GetList();

        /// <summary>
        /// 根据id集合或标签
        /// </summary>
        /// <param name="ids">id 集合</param>
        /// <returns></returns>
        List<TagsModel> GetList(params int[] ids);

        /// <summary>
        /// 根据文章获取标签集合
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        List<TagsModel> GetListByPost(int postId);

        /// <summary>
        /// 根据 titles 获取标签
        /// </summary>
        /// <param name="titles"></param>
        /// <returns></returns>
        List<TagsModel> GetTagsByTitles(params string[] titles);

        /// <summary>
        /// 根据 Title 索索
        /// </summary>
        /// <param name="titleLike">title</param>
        /// <returns></returns>
        List<TagsModel> Search(string titleLike, bool isName = false);

        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tag">要新增的标签</param>
        /// <returns></returns>
        int Insert(TagsModel tag);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        int InsertRange(List<TagsModel> tags);

        /// <summary>
        /// 修改标签
        /// </summary>
        /// <param name="tag">要修改的标签</param>
        /// <returns></returns>
        int Update(TagsModel tag);

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="ids">标签id集合</param>
        /// <returns></returns>
        int Delete(params int[] ids);
    }
}
