using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulaqCMS.RazorTemplate
{
    public static class TemplateParser
    {
        //public static string Execute(string razorTemplate, dynamic model)
        //{
        //    RazorTemplateParser rtp = new RazorTemplateParser();

        //    return rtp.Execute(razorTemplate, "BulaqCMS.Template", GetClassName, model);
        //}

        public static string ExecuteIndex(string template, IDictionary<string,object> bulaqData)
        {
            RazorTemplateParser rtp = new RazorTemplateParser();
            return rtp.Execute(template, "BulaqCMS.RazorTemplate", GetClassName(), typeof(IndexTemplate).FullName, bulaqData);
        }

        private static string GetClassName()
        {
            return "_" + Guid.NewGuid().ToString().Replace("-", "_");
        }
    }
}
