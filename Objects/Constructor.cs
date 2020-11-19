using CodeBuilder.Generator;
using CodeBuilder.Statements;
using System.Collections.Generic;

namespace CodeBuilder.Objects
{
    /// <summary>
    /// The constructor on a class
    /// </summary>
    public class Constructor : CodeGenerator
    {
        /// <summary>Constructor arguments</summary>
        public List<Argument> Arguments { get; } = new List<Argument>();

        /// <summary>Constructor statements</summary>
        public List<Statement> Statements { get; } = new List<Statement>();

        protected Constructor(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }
}
