using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface ICommentOptionsDAL
    {
        /// <summary>
        /// 获取所有评论参数
        /// </summary>
        /// <returns></returns>
        List<CommentOptionsModel> GetList();

        /// <summary>
        /// 根据评论获取她的参数
        /// </summary>
        /// <param name="comId"></param>
        /// <returns></returns>
        List<CommentOptionsModel> GetList(int comId);

        /// <summary>
        /// 根据ID获取一个
        /// </summary>
        /// <param name="optionId">参数ID</param>
        /// <returns></returns>
        CommentOptionsModel One(int optionId);

        /// <summary>
        /// 插入参数
        /// </summary>
        /// <param name="option">参数</param>
        /// <returns></returns>
        int Insert(CommentOptionsModel option);

        /// <summary>
        /// 修改参数
        /// </summary>
        /// <param name="option">参数</param>
        /// <returns></returns>
        int Update(CommentOptionsModel option);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除标识 ID</param>
        /// <param name="isByComment">根据评论还是主键删除</param>
        /// <returns></returns>
        int Delete(int id, bool isByComment);

        /// <summary>
        /// 根据摸个键删除
        /// </summary>
        /// <param name="isByComment">是否根据评论ID删除</param>
        /// <param name="ids">键集合</param>
        /// <returns></returns>
        int Delete(bool isByComment, params int[] ids);
    }
}
