﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class Links : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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