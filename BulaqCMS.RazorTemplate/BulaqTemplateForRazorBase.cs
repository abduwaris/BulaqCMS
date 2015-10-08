using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Razor;

namespace BulaqCMS.RazorTemplate
{
    public abstract partial class BulaqTemplateForRazorBase
    {
        /// <summary>
        /// 输出流
        /// </summary>
        public StringWriter Output { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BulaqTemplateForRazorBase()
        {
            this.Output = new StringWriter();
            this.Dics = new Dictionary<string, object>();
            //this.Model = new {Title="Abduwaris Gujamniyaz" };
            Dics.Add("title", "Abduwaris");
        }

        /// <summary>
        /// 执行方法
        /// </summary>
        /// <returns></returns>
        public abstract void Execute();

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void Write(object obj)
        {
            this.Output.Write(obj);
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="value"></param>
        protected virtual void WriteLiteral(string value)
        {
            this.Output.Write(value);
        }

        // public dynamic Model { get; set; }

        public Dictionary<string, object> Dics { get; set; }

        protected void WriteAttribute(string p, Tuple<string, int> tuple1, Tuple<string, int> tuple2, Tuple<Tuple<string, int>, Tuple<object, int>, bool> tuple3)
        {
            Output.Write(tuple1.Item1);
            Output.Write(tuple3.Item2.Item1);
            Output.Write(tuple2.Item1);
        }
    }
}
