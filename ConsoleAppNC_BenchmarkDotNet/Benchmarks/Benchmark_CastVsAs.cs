using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_CastVsAs
    {
        private readonly object intObject = 123123123;
        private readonly object stringObject = "123";

        [Benchmark(Baseline = true)]
        public void CastNormal()
        {
            var a = (string)stringObject;
        }

        [Benchmark]
        public void CastAsString()
        {
            var a = stringObject as string;
        }

        [Benchmark]
        public void CastAsWithNull()
        {
            var a = intObject as string;
        }
    }
}
