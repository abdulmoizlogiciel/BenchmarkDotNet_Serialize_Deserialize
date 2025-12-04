using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Text.RegularExpressions;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class BenchmarkContainsVsRegex
    {
        private readonly Regex _regex = new Regex("subscribe", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
        private static readonly Regex _regexTimeout = new Regex("subscribe", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.RightToLeft, TimeSpan.FromMilliseconds(3));

        [Params("gint/ord/sc/api/subscription/executions/unsubscribe/bulk", "bint/ord/sc/api/subscription/executions/unsubrscribe/bulk")]
        public string PotentialInput { get; set; }

        [Benchmark(Baseline = true)]
        public bool RegexMatch()
        {
            return _regex.IsMatch(PotentialInput);
        }

        [Benchmark]
        public bool RegexMatchWithTimeout()
        {
            return _regexTimeout.IsMatch(PotentialInput);
        }

        [Benchmark]
        public bool Contains()
        {
            return PotentialInput.Contains("subscribe", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
