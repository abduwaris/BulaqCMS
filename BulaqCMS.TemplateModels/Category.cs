using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.TemplateModels
{
    public class Category
    {
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 主题 Guid
        /// </summary>
        public string ThemeGuid { get; set; }

        /// <summary>
        /// 父
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }


        #region 额外参数

        /// <summary>
        /// 获取该分类下的所有文章, 推荐不要使用(特别是大型网站)
        /// </summary>
        public ICollection<Post> Posts { get; set; }

        Nullable<int> _PostsCount;

        /// <summary>
        /// 获取文章个数
        /// </summary>
        public int PostsCount
        {
            get
            {
                if (_PostsCount == null)
                {

                    _PostsCount = 0;
                }
                return _PostsCount.Value;
            }
        }

        /// <summary>
        /// 这个分类的子分类
        /// </summary>
        public ICollection<Category> Categories { get; set; }

        /// <summary>
        /// 这个分类父分类
        /// </summary>
        public Category Parent { get; set; }

        #endregion

        #region 方法

        /// <summary>
        /// 分页获取该分类下文章
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ICollection<Post> GetPage(int pageIndex, int pageSize)
        {

            return null;
        }

        #endregion

        #region 静态方法



        #endregion
    }
}
