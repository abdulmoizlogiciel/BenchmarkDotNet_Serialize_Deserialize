using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class BenchmarkArrayVsList
    {
        private const int Count = 50;
        private readonly string[] StringArray = Enumerable.Range(1, Count).Select(i => i.ToString()).ToArray();
        private readonly ICollection<string> StringList = Enumerable.Range(1, Count).Select(i => i.ToString()).ToList();

        [Benchmark]
        public void ForeachOnList()
        {
            _ = StringList.Select(s => s);
            //foreach (var item in StringList)
            //    _ = item;
        }

        [Benchmark(Baseline = true)]
        public void ForeachOnArray()
        {
            _ = StringArray.Select(s => s);
            //foreach (var item in StringArray)
            //    _ = item;
        }
    }
}
