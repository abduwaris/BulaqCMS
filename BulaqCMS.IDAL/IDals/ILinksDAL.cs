using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface ILinksDAL
    {
        /// <summary>
        /// 获取所有连接
        /// </summary>
        /// <returns></returns>
        List<LinksModel> GetList();

        /// <summary>
        /// 新增连接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int Insert(LinksModel link);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int Update(LinksModel link);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);
    }
}
