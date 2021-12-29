namespace ConsoleAppNC_BenchmarkDotNet.Models
{
    public class BenchmarkConfig : BenchmarkDotNet.Configs.ManualConfig
    {
        public BenchmarkConfig()
        {
            SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(BenchmarkDotNet.Columns.RatioStyle.Percentage);
        }
    }
}
