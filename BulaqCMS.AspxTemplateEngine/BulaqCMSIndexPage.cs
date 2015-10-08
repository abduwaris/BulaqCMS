using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.AspxTemplate
{
    public class BulaqCMSIndexPage : BulaqCMSPageBase
    {

        public ICollection<PostsModel> Posts { get; set; }

        public int pageIndex { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            pageIndex = Convert.ToInt32(Request["PageIndex"]);

            var query = Request.QueryString;
            //string postName = Request.QueryString["PostName"];
            int totalCount = 0;
            //获取文章
            Posts = Service.PostsService.GetPostsByPage(10, 1, out totalCount, true);

            base.OnLoad(e);
            //throw new ArgumentException();

            var post = BulaqCMS.TemplateModels.Post.GetPostsByPage(1, 10);
        }

        protected override void OnInit(EventArgs e)
        {

            //base.OnInit(e);
        }
    }
}
