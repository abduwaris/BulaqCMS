using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface IOptionsDAL
    {
        /// <summary>
        /// 获取所有Option
        /// </summary>
        /// <returns></returns>
        List<OptionsModel> GetList();

        /// <summary>
        /// 新增系统参数
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        int Insert(OptionsModel option);

        /// <summary>
        /// 修改参数
        /// </summary>
        /// <param name="option">要修改的参数</param>
        /// <returns></returns>
        int Update(OptionsModel option);

        /// <summary>
        /// 删除制定的 Option
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);
    }
}
