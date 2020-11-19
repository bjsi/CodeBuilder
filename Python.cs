using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeBuilder
{
    public static class Const
    {
        public static string TemplateFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Templates");
    }

    public class PythonThisFieldRef : ThisFieldReference
    {

        public override string ThisName => "self";

        public PythonThisFieldRef(string fieldName)
        {
            this.FieldName = fieldName;
        }
    }

    public class PythonMethodInvoke : MethodInvoke
    {
        public PythonMethodInvoke(string name, params string[] args)
        {
            this.MethodName = name;
            this.WithArguments(args);
        }

        public PythonMethodInvoke WithArgument(string arg)
        {
            this.Arguments.Add(arg);
            return this;
        }

        public PythonMethodInvoke WithArguments(IEnumerable<string> args)
        {
            this.Arguments.AddRange(args);
            return this;
        }
    }

    public class PythonField : Field
    {

        private static string TemplateFilePath = Path.Combine(Const.TemplateFolderPath, "PythonField.Mustache");

        public PythonField(string name, string type)
            : base(TemplateFilePath)
        {
            this.Name = name;
            this.Type = type;
        }

        public PythonField WithComment(string comment)
        {
            this.Comment = (comment);
            return this;
        }

    }

    public class PythonAssignmentStatement : AssignmentStatement
    {
        private static string TemplateFilePath = Path.Combine(Const.TemplateFolderPath, "PythonAssignment.Mustache");
        public PythonAssignmentStatement(string lhs, string rhs)
            : base(TemplateFilePath)
        {
            this.LHS = lhs;
            this.RHS = rhs;
        }
    }

    public class PythonReturnStatement : ReturnStatement
    {

        private static string TemplateFilePath = Path.Combine(Const.TemplateFolderPath, "PythonReturn.Mustache");

        public PythonReturnStatement(string rhs)
            :base(TemplateFilePath)
        {
            this.RHS = rhs;
        }

    }


    public class PythonArgument : Argument
    {

        private static string TemplateFilePath = Path.Combine(Const.TemplateFolderPath, "PythonConstructor.Mustache");

        public PythonArgument(string name, string type)

            : base(TemplateFilePath)
        {
            this.Name = name;
            this.Type = type;
        }

    }

    public class PythonConstructor : Constructor
    {
        private static string TemplateFilePath = Path.Combine(Const.TemplateFolderPath, "PythonConstructor.Mustache");

        public PythonConstructor()

            : base(TemplateFilePath)
        {
        }

        public PythonConstructor WithArgument(Argument arg)
        {
            this.Arguments.Add(arg);
            return this;
        }

        public PythonConstructor WithArguments(IEnumerable<Argument> args)
        {
            this.Arguments.AddRange(args);
            return this;
        }

        public PythonConstructor WithStatement(AssignmentStatement statement)
        {
            this.Statements.Add(statement);
            return this;
        }

        public PythonConstructor WithStatement(ReturnStatement statement)
        {
            this.Statements.Add(statement);
            return this;
        }
    }

    public class PythonClass : Class
    {

        private static string TemplateFilePath = Path.Combine(Const.TemplateFolderPath, "PythonClass.Mustache");

        public PythonClass(string name)
            : base(TemplateFilePath)
        {
            this.Name = name;
        }

        public string BaseString => string.Join(", ", this.Bases);
        public string CommentString => string.Join("\n\t", this.Comments);

        public PythonClass WithField(PythonField field)
        {
            this.Fields.Add(field);
            return this;
        }

        public PythonClass WithFields(IEnumerable<PythonField> fields)
        {
            this.Fields.AddRange(fields);
            return this;
        }

        public PythonClass WithBaseClasses(IEnumerable<string> klasses)
        {
            this.Bases.AddRange(klasses);
            return this;
        }

        public PythonClass WithBaseClass(string klass)
        {
            this.Bases.Add(klass);
            return this;
        }

        public PythonClass WithComment(string comment)
        {
            this.Comments.Add(comment);
            return this;
        }

        public PythonClass WithConstructor(PythonConstructor cons)
        {
            this.Constructor = cons;
            return this;
        }

        public PythonClass WithMethod(PythonMethod method)
        {
            this.Methods.Add(method);
            return this;
        }
    }

    public class PythonMethod : Method
    {

        private static string TemplateFilePath = Path.Combine(Const.TemplateFolderPath, "PythonMethod.Mustache");
        public bool IsAsync { get; }

        public PythonMethod(string name, bool async, string returnType) 
            : base(TemplateFilePath)
        {
            this.Name = name;
            this.IsAsync = async;
            this.ReturnType = returnType;
        }

        public string ArgumentsString => string.Join(", ", Arguments.Select(x => $"{x.Name}: {x.Type}"));
        public string CommentsString => string.Join("\n\t", Comments);

        public PythonMethod WithComment(string comment)
        {
            this.Comments.Add(comment);
            return this;
        }

        public PythonMethod WithArgument(Argument arg)
        {
            this.Arguments.Add(arg);
            return this;
        }

        public PythonMethod WithArguments(IEnumerable<Argument> args)
        {
            this.Arguments.AddRange(args);
            return this;
        }

        public PythonMethod WithStatement(AssignmentStatement statement)
        {
            this.Statements.Add(statement);
            return this;
        }

        public PythonMethod WithStatement(ReturnStatement statement)
        {
            this.Statements.Add(statement);
            return this;
        }
    }
}
