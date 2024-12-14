using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class BenchmarkDelegateVsArrow
    {
        [Benchmark(Baseline = true)]
        public Action Delegate()
        {
            return delegate { Caller(6); };
        }

        [Benchmark]
        public Action Anonymous()
        {
            return () => Caller(6);
        }

        private void Caller(int count)
        {
            _ = (count + 1) % 10;
        }
    }
}
