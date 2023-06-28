using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_IEnumerableVsICollection
    {
        private readonly List<string> _items = new List<string>
        {
            "user1",
            "user2",
            "user3",
            "user4",
            "user5",
            "user6",
            "user7",
            "user9",
        };


        [Benchmark(Baseline = true)]
        public void IEnumerable_Any()
        {
            IEnumerable<string> items = _items;
            if (items.Any())
            {
            }
        }

        [Benchmark]
        public void ICollection_Count()
        {
            ICollection<string> items = _items;
            if (items.Count != 0)
            {
            }
        }

        [Benchmark]
        public void IList_Count()
        {
            IList<string> items = _items;
            if (items.Count != 0)
            {
            }
        }

        [Benchmark]
        public void List_Count()
        {
            var items = _items;
            if (items.Count != 0)
            {
            }
        }
    }
}
