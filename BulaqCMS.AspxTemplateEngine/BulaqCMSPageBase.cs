using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using BulaqCMS.Models;
using BulaqCMS.BLL;

namespace BulaqCMS.AspxTemplate
{
    /// <summary>
    /// 模板机制
    /// </summary>
    public class BulaqCMSPageBase : Page
    {

        /// <summary>
        /// 所有专辑
        /// </summary>
        public ICollection<CategoriesModel> Categories { get; set; }

        /// <summary>
        /// 所有标签
        /// </summary>
        public ICollection<TagsModel> Tags { get; set; }

        /// <summary>
        /// 所有菜单
        /// </summary>
        public ICollection<NavGroupModel> Navs { get; set; }

        /// <summary>
        /// 默认菜单
        /// </summary>
        public NavGroupModel DefaultNav
        {
            get
            {
                if (Navs == null || Navs.Count <= 0)
                    return new NavGroupModel();
                return Navs.FirstOrDefault(p => p.Name.ToLower() == "default") ?? Navs.FirstOrDefault();
            }
        }

        /// <summary>
        /// 最新文章
        /// </summary>
        public ICollection<CommentsModel> NewComments { get; set; }


        /// <summary>
        /// 所有连接
        /// </summary>
        public ICollection<LinksModel> Links { get; set; }

        /// <summary>
        /// 友情连接
        /// </summary>
        public ICollection<LinksModel> FriendlyLink
        {
            get
            {
                if (Links == null || Links.Count <= 0)
                    return new List<LinksModel>();
                return Links.Where(p => p.Name.ToLower() == "friendly").ToList();
            }
        }

        /// <summary>
        /// 获取文章转进
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public S GetPostOprion<S>(PostsModel post, string key) where S : new()
        {

            return default(S);
        }

        /// <summary>
        /// 获取文章转进
        /// </summary>
        public object GetPostOption(PostsModel post, string key)
        {
            return null;
        }

        /// <summary>
        /// 逻辑层操作对象
        /// </summary>
        public ServiceSession Service
        {
            get
            {
                return BLLServiceFactory.CreateServiceSession();
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            //获取所有标签
            Tags = Service.TagsService.GetList(true);
            //获取所有分类
            Categories = Service.CategoriesService.GetList(true);
            //获取所有菜单
            Navs = Service.NavGroupService.GetList(true, true);
            //连接
            Links = Service.LinksService.GetList();

            base.OnLoad(e);

        }
    }
}
