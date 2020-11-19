using CodeBuilder.Generator;

namespace CodeBuilder.Statements
{
    public abstract class Statement : CodeGenerator
    {
        protected Statement(string templateFilePath)
            : base(templateFilePath)
        {
        }
    }
}
