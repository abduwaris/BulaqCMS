using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class __Admin : System.Web.UI.MasterPage
    {
        protected AdminBasePage Pages { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Pages = (AdminBasePage)this.Page;
        }
    }
}