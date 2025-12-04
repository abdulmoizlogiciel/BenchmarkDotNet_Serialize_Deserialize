using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_DictionaryVsConcurrentDictionary
    {
        public static ConcurrentDictionary<string, string> _concurrentDict = new ConcurrentDictionary<string, string>();
        public static IDictionary<string, string> _dict = new Dictionary<string, string>();
        public Benchmark_DictionaryVsConcurrentDictionary()
        {
            _concurrentDict.TryAdd("ee", "rr");
            _dict.Add("ee", "rr");
        }

        [Benchmark(Baseline = true)]
        public void Dictionary_WithLock()
        {
            lock (_dict)
            {
                _ = _dict.ContainsKey("tt");
            }
        }

        [Benchmark]
        public void ConcurrentDictionary()
        {
            _ = _concurrentDict.ContainsKey("tt");
        }
    }
}
