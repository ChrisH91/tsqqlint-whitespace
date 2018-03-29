namespace TSQLLint.Plugins.WhiteSpace
{
    using System;
    using TSQLLint.Common;

    public class TrailingWhiteSpace
    {
        private readonly IPluginContext context;
        private readonly IReporter reporter;

        public TrailingWhiteSpace(IPluginContext context, IReporter reporter)
        {
            this.context = context;
            this.reporter = reporter;
        }

        public void ParseLine(string line, int lineNumber)
        {
            if (line.Length <= 0)
            {
                return;
            }

            if (line[line.Length - 1] == ' ' || line[line.Length - 1] == '\t')
            {
                reporter.ReportViolation(new RuleViolation(
                    this.context.FilePath,
                    "trailing-whitespace",
                    "Remove trailing white space",
                    lineNumber,
                    line.Length,
                    RuleViolationSeverity.Error));
            }
        }
    }
}