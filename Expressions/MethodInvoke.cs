using System.Collections.Generic;

namespace CodeBuilder.Expressions
{
    /// <summary>
    /// Represents the invocation of a method
    /// </summary>
    public abstract class MethodInvoke
    {
        /// <summary>Arguments to be passed to the method</summary>
        public List<string> Arguments { get; set; } = new List<string>();

        /// <summary>Name of the method</summary>
        public string MethodName { get; set; }

        public override string ToString() => $"{MethodName}({string.Join(", ", Arguments)})";
    }
}
