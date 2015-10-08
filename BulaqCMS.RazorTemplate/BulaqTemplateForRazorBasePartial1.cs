using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.RazorTemplate
{
    public abstract partial class BulaqTemplateForRazorBase
    {

        public virtual void SetProperty(IDictionary<string, object> bulaqData) { }

        ///// <summary>
        ///// 布局页
        ///// </summary>
        //public string Layout { get; set; }

        public string GetScripts(string scriptName)
        {
            return string.Empty;
        }
    }
}
