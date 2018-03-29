
namespace TSQLLint.Plugins.WhiteSpace
{
    using System;
    using TSQLLint.Common;

    public class WhiteSpacePlugin : IPlugin
    {
        public void PerformAction(IPluginContext context, IReporter reporter)
        {
            var preferSpaces = new PreferSpaces(context, reporter);
            var trailingWhiteSpace = new TrailingWhiteSpace(context, reporter);
            var indentation = new Indentation(context, reporter);

            string line;
            var lineNumber = 0;

            while ((line = context.FileContents.ReadLine()) != null)
            {
                lineNumber++;

                preferSpaces.ParseLine(line, lineNumber);
                trailingWhiteSpace.ParseLine(line, lineNumber);
                indentation.ParseLine(line, lineNumber);
            }
        }
    }
}