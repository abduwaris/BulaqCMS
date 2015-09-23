using BulaqCMS.Common;
using BulaqCMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulaqCMS.Admin
{
    public partial class EditCategories : AdminBasePage
    {
        protected List<CategoriesModel> Categories;

        protected void Page_Load(object sender, EventArgs e)
        {
            Categories = Service.CategoriesService.GetList();
        }
        public override string ActivePage
        {
            get
            {
                return "post-cats";
            }
        }

        
    }
}