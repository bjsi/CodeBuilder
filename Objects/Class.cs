using CodeBuilder.Generator;
using System.Collections.Generic;

namespace CodeBuilder.Objects
{
    /// <summary>
    /// Represents a class.
    /// </summary>
    public abstract class Class : CodeGenerator
    {

        /// <summary>The name of the class</summary>
        public string Name { get; set; }

        /// <summary>Comments on the clas</summary>
        public List<string> Comments { get; set; } = new List<string>();

        /// <summary>Classes the class inherits from.</summary>
        public List<string> Bases { get; set; } = new List<string>();

        /// <summary>Class' methods</summary>
        public List<Method> Methods { get; set; } = new List<Method>();

        /// <inheritdoc/>
        public Constructor Constructor { get; set; }

        /// <summary>Fields defined on the class</summary>
        public List<Field> Fields { get; set; } = new List<Field>();

        protected Class(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }
}
