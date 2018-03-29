namespace TSQLLint.Plugins.WhiteSpace
{
    using System;
    using TSQLLint.Common;

    public class PreferSpaces
    {
        private readonly IPluginContext context;
        private readonly IReporter reporter;

        public PreferSpaces(IPluginContext context, IReporter reporter)
        {
            this.context = context;
            this.reporter = reporter;
        }

        public void ParseLine(string line, int lineNumber)
        {
            var column = line.IndexOf("\t", StringComparison.Ordinal);

            if (column == -1)
            {
                return;
            }

            reporter.ReportViolation(new RuleViolation(
                this.context.FilePath,
                "prefer-spaces",
                "Should use spaces rather than tabs",
                lineNumber,
                1,
                RuleViolationSeverity.Error));
        }
    }
}