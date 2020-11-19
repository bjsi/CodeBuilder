using Stubble.Core.Builders;
using System.IO;
using System.Text;

namespace CodeBuilder.Generator
{
    public abstract class CodeGenerator
    {
        /// <summary>
        /// The path to the mustache template file.
        /// </summary>
        private string TemplateFilePath { get; }

        public CodeGenerator(string templateFilePath)
        {
            this.TemplateFilePath = templateFilePath;
        }

        /// <inheritdoc cref="Generate"/>
        public override string ToString() => Generate();

        /// <summary>
        /// Generates the source code.
        /// </summary>
        /// <returns>The generated source code</returns>
        public string Generate()
        {
            var stubble = new StubbleBuilder().Build();
            using (StreamReader streamReader = new StreamReader(TemplateFilePath, Encoding.UTF8))
            {
                return stubble.Render(streamReader.ReadToEnd(), this, new Stubble.Core.Settings.RenderSettings { SkipHtmlEncoding = true });
            }
        }
    }
}
