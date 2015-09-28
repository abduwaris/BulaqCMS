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

        public static Dictionary<string, string> linkInGuids;
        /// <summary>
        /// 所有连接
        /// </summary>
        protected List<LinksModel> allLinks;

        protected List<string> linkGroups;

        protected string filter = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            allLinks = Service.LinksService.GetList();
            linkGroups = allLinks.Select(p => p.Name).Where(p => p.Trim() != "").Distinct().ToList();
            //判断是否filter
            if (!stringNull(Request.QueryString["group"]))
            {
                //filter = Uri.UnescapeDataString(Request.QueryString["group"]);
                filter = Request.QueryString["group"].Trim();
                if (filter != "")
                {
                    allLinks = allLinks.Where(p => linkInGuids[filter] == p.Name).ToList();
                }
            }
        }

        public override string ActivePage
        {
            get
            {
                return "link-links";
            }
        }

        protected override void OnInit(EventArgs e)
        {
            if (linkInGuids == null)
            {
                var linksN = Service.LinksService.GetList().Select(p => p.Name).Where(p => p.Trim() != "").Distinct().ToList();
                linkInGuids = linksN.ToDictionary<string, string>(p => Guid.NewGuid().ToString());
            }
            base.OnInit(e);
        }
    }
}