using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Razor;
using System.Web.Razor.Generator;

namespace BulaqCMS.RazorTemplate
{
    public class RazorTemplateParser
    {
        public string LastGeneratedCode { get; set; }
        public string Execute(string TemplateCode, string defaultnamespace, string defaultclassname, string baseClassFullName, IDictionary<string, object> bulaqData)
        {
            string resultstring = null;
            var parseresult = ParseToCode(TemplateCode, defaultnamespace, defaultclassname, baseClassFullName);
            resultstring = ExecuteInternal(parseresult, defaultnamespace, defaultclassname, bulaqData);
            return resultstring;
        }

        private string ExecuteInternal(GeneratorResults razorResults, string defaultnamespace, string defaultclassname, IDictionary<string, object> bulaqData)
        {
            using (var provider = new CSharpCodeProvider())
            {
                var compiler = new CompilerParameters();
                compiler.ReferencedAssemblies.Add("System.dll");
                compiler.ReferencedAssemblies.Add("System.Core.dll");
                compiler.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                compiler.ReferencedAssemblies.Add(AppDomain.CurrentDomain.BaseDirectory + "\\bin\\BulaqCMS.Models.dll");
                compiler.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
                compiler.GenerateInMemory = true;
                var result = provider.CompileAssemblyFromDom(compiler, razorResults.GeneratedCode);
                if (result.Errors.HasErrors)
                {
                    var error = result.Errors.OfType<CompilerError>().Where(i => !i.IsWarning).FirstOrDefault();
                    if (error != null) throw new Exception(error.ErrorText); //抛出错误
                }
                BulaqTemplateForRazorBase temp = (BulaqTemplateForRazorBase)result.CompiledAssembly.CreateInstance(defaultnamespace + "." + defaultclassname);
                //temp.Model = new { Title = "Abduwaris" };//Model;
                temp.SetProperty(bulaqData);
                //if (temp.Layout != null)
                //{
                //    //有布局页

                //}
                try
                {
                    temp.Execute();
                }
                catch (Exception ex)
                {
                    throw new Exception("执行错误", ex);
                }
                return temp.Output.ToString();
            }
        }

        public GeneratorResults ParseToCode(string TemplateCode, string defaultnamespace, string defaultclassname, string baseClassFullName)
        {
            GeneratorResults razorResults;
            var host = new RazorEngineHost(new CSharpRazorCodeLanguage());
            host.DefaultBaseClass = baseClassFullName;//typeof(BulaqTemplateForRazorBase).FullName;
            host.DefaultNamespace = defaultnamespace;
            host.DefaultClassName = defaultclassname;
            host.NamespaceImports.Add("System");
            host.NamespaceImports.Add("BulaqCMS.Models");
            host.GeneratedClassContext = new GeneratedClassContext("Execute", "Write", "WriteLiteral");
            var engine = new RazorTemplateEngine(host);
            using (var reader = new StringReader(TemplateCode))
            {
                razorResults = engine.GenerateCode(reader);
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                options.BracingStyle = "C";
                using (StringWriter writer = new StringWriter())
                {
                    IndentedTextWriter indentwriter = new IndentedTextWriter(writer, "    ");
                    codeProvider.GenerateCodeFromCompileUnit(razorResults.GeneratedCode, indentwriter, options);
                    indentwriter.Flush();
                    indentwriter.Close();
                    LastGeneratedCode = writer.GetStringBuilder().ToString();
                    string codePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\code.cs";
                    File.WriteAllText(codePath, LastGeneratedCode, Encoding.UTF8);
                }
            }
            return razorResults;
        }
    }
}
