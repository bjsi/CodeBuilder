using CodeBuilder.Helpers;

namespace CodeBuilder.Objects
{
    /// <summary>
    /// An argument to a method or function.
    /// </summary>
    public abstract class Argument
    {
        /// <summary>Name of the argument</summary>
        public string Name { get; set; }

        /// <summary>Type of the argument</summary>
        public string Type { get; set; }

        public override string ToString()
        {
            return Type.IsNullOrEmpty()
                ? $"{Name}"
                : $"{Name}: {Type}";
        } 
    }
}
