using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.TemplateModels
{
    public class Tag
    {
        /// <summary>
        /// 主键 ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; }

        #region 额外参数

        ICollection<Post> _Posts;

        /// <summary>
        /// 该标签下所有文章
        /// </summary>
        public ICollection<Post> Posts
        {
            get
            {
                if (_Posts == null)
                {

                }
                return _Posts;
            }
        }

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
                    //从数据库中获取
                    _PostsCount = 0;
                }
                return _PostsCount.Value;
            }
        }

        /// <summary>
        /// 是否有文章
        /// </summary>
        public bool HasPosts
        {
            get
            {
                return this.Posts != null && this.Posts.Count > 0;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 分页获取文章
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <returns></returns>
        public ICollection<Post> GetPage(int pageIndex, int pageSize)
        {
            return default(ICollection<Post>);
        }

        #endregion
    }
}
