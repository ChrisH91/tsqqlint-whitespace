namespace TSQLLint.Plugins.WhiteSpace
{
    using System;
    using System.Linq;
    using TSQLLint.Common;

    class Indentation
    {
        private readonly IPluginContext context;
        private readonly IReporter reporter;

        public Indentation(IPluginContext context, IReporter reporter)
        {
            this.context = context;
            this.reporter = reporter;
        }

        public void ParseLine(string line, int lineNumber)
        {
            var whiteSpaceLength = line.TakeWhile(c => c == ' ').Count();

            if (whiteSpaceLength % 4 == 0)
            {
                return;
            }

            reporter.ReportViolation(new RuleViolation(
                this.context.FilePath,
                "indentation",
                "Indentation should be 4 spaces",
                lineNumber,
                line.Length,
                RuleViolationSeverity.Error));
        }
    }
}
