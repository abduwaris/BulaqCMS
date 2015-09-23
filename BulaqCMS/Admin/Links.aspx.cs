using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BulaqCMS.Models;

namespace BulaqCMS.Admin
{
    public partial class Links : AdminBasePage
    {
        /// <summary>
        /// 所有连接
        /// </summary>
        protected List<LinksModel> allLinks;
        protected void Page_Load(object sender, EventArgs e)
        {
            allLinks = Service.LinksService.GetList();
        }

        public override string ActivePage
        {
            get
            {
                return "link-links";
            }
        }
    }
}