using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.DAL.MySql
{
    public abstract class BaseDAL<TModel>
    {
        /// <summary>
        /// 把表转换成模型集合
        /// </summary>
        /// <param name="dt">表</param>
        /// <returns></returns>
       protected List<TModel> ToModelList(DataTable dt)
        {
            List<TModel> tags = new List<TModel>();
            if (dt != null && dt.Rows.Count > 0)
                foreach (DataRow row in dt.Rows)
                    tags.Add(ToModel(row));
            return tags;
        }
        /// <summary>
        /// 关西转换成模型
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        protected abstract TModel ToModel(DataRow row);
    }
}
