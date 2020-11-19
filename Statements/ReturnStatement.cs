namespace CodeBuilder.Statements
{
    /// <summary>
    /// Represents a return statement in a function or method.
    /// </summary>
    public abstract class ReturnStatement : Statement
    {
        /// <summary>The right hand side of the return statement.</summary>
        public string RHS { get; set; }

        protected ReturnStatement(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }
}
