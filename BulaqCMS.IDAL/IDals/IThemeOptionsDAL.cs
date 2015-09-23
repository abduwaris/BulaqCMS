using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.IDAL
{
    public interface IThemeOptionsDAL
    {
        /// <summary>
        /// 获取摸个主题的某些参数
        /// </summary>
        /// <param name="guid">根据主题标识符获取参数,null:获取所有</param>
        /// <returns></returns>
        List<ThemeOptionsModel> GetList(string guid);

        /// <summary>
        /// 添加新的 Options
        /// </summary>
        /// <param name="option">要添加的对象</param>
        /// <returns></returns>
        int Insert(ThemeOptionsModel option);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="option">要修改 Option</param>
        /// <returns></returns>
        int Update(ThemeOptionsModel option);

        /// <summary>
        /// 根据 ID 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);

        /// <summary>
        /// 根据主题删除
        /// </summary>
        /// <param name="guid">主题标识符</param>
        /// <returns></returns>
        int Delete(string guid);
    }
}
