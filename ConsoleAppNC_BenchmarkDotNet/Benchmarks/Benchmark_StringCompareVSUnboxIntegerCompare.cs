using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_StringCompareVSUnboxIntegerCompare
    {
        private static readonly object _boxedInteger = 123456;
        private static readonly string _stringMsg = "MKTWSERROR_123456";

        [Benchmark(Description = "CompareStringOrdinal")]
        public bool CompareStringOrdinal()
        {
            return _stringMsg.Equals("MKTWSERROR_123456", StringComparison.Ordinal);
        }

        [Benchmark(Description = "UnboxIntegerThenCompare", Baseline = true)]
        public bool UnboxIntegerThenCompare()
        {
            return (int)_boxedInteger == 99;
        }
    }
}
