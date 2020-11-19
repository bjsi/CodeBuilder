namespace CodeBuilder.Statements
{
    /// <summary>
    /// Represents an assignment statement.
    /// </summary>
    public abstract class Assignment : Statement
    {
        /// <summary>Left hand side of the assignment statement</summary>
        public string LHS { get; set; }

        /// <summary>Right hand side of the assignment statement</summary>
        public string RHS { get; set; }

        protected Assignment(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }
}
