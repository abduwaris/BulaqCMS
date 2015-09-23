using BulaqCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class link_editor : AdminBasePage
    {
        /// <summary>
        /// 所有连接
        /// </summary>
        protected List<LinksModel> allLinks;
        /// <summary>
        /// 要修改的连接
        /// </summary>
        protected LinksModel UpdateLinks;

        protected bool isEdit = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            allLinks = Service.LinksService.GetList();
            string mode = stringNull(Request["mode"]) ? "new" : Request["mode"].Trim().ToLower();
            if (mode != "new" && mode != "edit") mode = "new";
            if (mode == "edit")
            {
                int linkId = 0;
                if (!stringNull(Request["linkid"]) && int.TryParse(Request["linkid"].Trim(), out linkId))
                {
                    UpdateLinks = allLinks.FirstOrDefault(p => p.ID == linkId);
                    if (UpdateLinks != null) isEdit = true;
                }
            }
        }

        public override string ActivePage
        {
            get
            {
                return "link-editor";
            }
        }
    }
}