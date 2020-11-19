using CodeBuilder.Generator;
using CodeBuilder.Statements;
using System.Collections.Generic;

namespace CodeBuilder.Objects
{
    /// <summary>
    /// Represents a class method
    /// </summary>
    public abstract class Method : CodeGenerator
    {
        /// <summary>Method name</summary>
        public string Name { get; set; }

        /// <summary>Method return type</summary>
        public string ReturnType { get; set; }

        /// <summary>Method comments</summary>
        public List<string> Comments { get; } = new List<string>();

        /// <summary>Method arguments</summary>
        public List<Argument> Arguments { get; } = new List<Argument>();

        /// <summary>Method statements</summary>
        public List<Statement> Statements { get; } = new List<Statement>();

        protected Method(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }
}
