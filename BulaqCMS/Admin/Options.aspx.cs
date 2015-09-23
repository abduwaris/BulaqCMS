using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class Options : AdminBasePage
    {
        /// <summary>
        /// 链接方式
        /// </summary>
        protected string Mode { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public override string ActivePage
        {
            get
            {
                return "option";
            }
        }
    }
}