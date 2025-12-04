using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_StringComparison
    {
        public static string s1 = "Strasse";
        public static string s2 = "Straße";
        [Benchmark(Baseline = true)]
        public void Ordinal()
        {
            var r1 = string.Equals(s1, s2, StringComparison.Ordinal);
        }

        [Benchmark]
        public void InvariantCulture()
        {
            var r2 = string.Equals(s1, s2, StringComparison.InvariantCulture);
        }
        [Benchmark]
        public void CurrentCulture()
        {
            var r3 = string.Equals(s1, s2, StringComparison.CurrentCulture);
        }
        [Benchmark]
        public void OrdinalIgnoreCase()
        {
            var r4 = string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
        }

    }
}
