namespace TSQLLint.Plugins.WhiteSpace
{
    using TSQLLint.Common;

    public class LineLength
    {
        private readonly IPluginContext context;
        private readonly IReporter reporter;

        public LineLength(IPluginContext context, IReporter reporter)
        {
            this.context = context;
            this.reporter = reporter;
        }

        public void ParseLine(string line, int lineNumber)
        {
            if (line.Length <= 100)
            {
                return;
            }

            reporter.ReportViolation(new RuleViolation(
                this.context.FilePath,
                "line-length",
                "Line must not exceed 100 characters",
                101,
                1,
                RuleViolationSeverity.Error));
        }
    }
}