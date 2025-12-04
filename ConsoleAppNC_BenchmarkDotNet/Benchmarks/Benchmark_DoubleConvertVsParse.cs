using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_DoubleConvertVsParse
    {
        private readonly object _data = -.0125;

        [Benchmark(Baseline = true)]
        public void ConvertToDouble()
        {
            Convert.ToDouble(_data);
        }

        [Benchmark]
        public void Double_Parse()
        {
            double.Parse(_data.ToString());
        }
    }
}
