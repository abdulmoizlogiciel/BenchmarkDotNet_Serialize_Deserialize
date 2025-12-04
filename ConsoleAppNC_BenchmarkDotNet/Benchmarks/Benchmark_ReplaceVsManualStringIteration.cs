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
    public class Benchmark_ReplaceVsManualStringIteration
    {
        private static readonly string _longStringMsg = new string('A', 200) + "\r\n";

        [Benchmark(Description = ".NET's Replace", Baseline = true)]
        public string Replace()
        {
            return _longStringMsg.Replace('\r', ' ').Replace('\n', ' ');
        }

        [Benchmark(Description = "StringBuilderManualLoop")]
        public string StringBuilderManualLoop()
        {
            var builder = new StringBuilder();
            for (int index = 0; index < _longStringMsg.Length; index++)
            {
                char currentChar = _longStringMsg[index];
                if (currentChar != '\r' && currentChar != '\n')
                {
                    builder.Append(currentChar);
                }
            }
            return builder.ToString();
        }
    }
}
