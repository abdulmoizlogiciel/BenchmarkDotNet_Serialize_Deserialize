using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Text.RegularExpressions;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class BenchmarkIfConditionVsMath
    {
        private readonly int Limit = 6;

        [Benchmark(Baseline = true)]
        public void IfCondition()
        {
            int count = 5;

            count++;
            if (count >= Limit)
            {
                count = 0;
            }
        }

        [Benchmark]
        public void Math()
        {
            int count = 5;

            count = (count + 1) % Limit;
        }
    }
}
