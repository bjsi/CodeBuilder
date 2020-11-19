using Stubble.Core.Builders;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeBuilder
{

    public abstract class SourceCodeGenerator
    {
        private string TemplateFilePath { get; }

        public SourceCodeGenerator(string templateFilePath)
        {
            this.TemplateFilePath = templateFilePath;
        }

        public string Generate()
        {
            var stubble = new StubbleBuilder().Build();
            using (StreamReader streamReader = new StreamReader(TemplateFilePath, Encoding.UTF8))
            {
                return stubble.Render(streamReader.ReadToEnd(), this, new Stubble.Core.Settings.RenderSettings { SkipHtmlEncoding = true });
            }
        }
    }

    public abstract class ThisFieldReference
    {
        public abstract string ThisName { get; }
        public string FieldName { get; set; }
        public override string ToString() => ThisName + "." + FieldName;
    }

    public abstract class MethodInvoke
    {
        public List<string> Arguments { get; set; } = new List<string>();
        public string MethodName { get; set; }
        public override string ToString() => $"{MethodName}({string.Join(", ", Arguments)})";
    }

    public abstract class Statement : SourceCodeGenerator
    {
        protected Statement(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }

    public abstract class AssignmentStatement : Statement
    {
        public string LHS { get; set; }
        public string RHS { get; set; }
        protected AssignmentStatement(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }

    public abstract class ReturnStatement : Statement
    {
        public string RHS { get; set; }
        protected ReturnStatement(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }


    public abstract class Method : SourceCodeGenerator
    {
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public List<string> Comments { get; } = new List<string>();
        public List<Argument> Arguments { get; } = new List<Argument>();
        public List<Statement> Statements { get; } = new List<Statement>();

        protected Method(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }

    public abstract class Argument : SourceCodeGenerator
    {

        public string Name { get; set; }
        public string Type { get; set; }

        protected Argument(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }

    public abstract class Field : SourceCodeGenerator
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }

        protected Field(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }

    public abstract class Class : SourceCodeGenerator
    {

        public List<string> Comments { get; set; } = new List<string>();
        public List<string> Bases { get; set; } = new List<string>();
        public string Name { get; set; }
        public List<Method> Methods { get; set; } = new List<Method>();
        public Constructor Constructor { get; set; }
        public List<Field> Fields { get; set; } = new List<Field>();

        protected Class(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }

    public class Constructor : SourceCodeGenerator
    {
        public List<Argument> Arguments { get; } = new List<Argument>();
        public List<Statement> Statements { get; } = new List<Statement>();

        protected Constructor(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }
}
