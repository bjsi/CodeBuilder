using CodeBuilder.Generator;

namespace CodeBuilder.Objects
{
    /// <summary>
    /// Represents a field member of a class.
    /// </summary>
    public abstract class Field : CodeGenerator
    {
        /// <summary>The name of the field</summary>
        public string Name { get; set; }

        /// <summary>The type of the field</summary>
        public string Type { get; set; }

        /// <summary>Comments on the field</summary>
        public string Comment { get; set; }

        protected Field(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }
}
