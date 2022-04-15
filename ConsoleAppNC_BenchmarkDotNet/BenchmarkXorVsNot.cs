using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class BenchmarkXorVsNot
    {
        private readonly Regex regex = new(@".*");
        private readonly List<string> list = new() { "asdf", "asdf", "asdf", "asdf", };
        private readonly bool BoolField;

        [Benchmark(Baseline = true)]
        public bool Not()
        {
            return list.Any(item => !regex.IsMatch(item));
            //if (!BoolField)
            //{
            //    _ = "The program ConsoleAppNC_BenchmarkDotNet.exe has exited with code 0 (0x0)";
            //}
        }

        [Benchmark]
        public bool Xor()
        {
            return list.Any(item => regex.IsMatch(item) ^ true);
            //if (BoolField ^ true)
            //{
            //    _ = "The program ConsoleAppNC_BenchmarkDotNet.exe has exited with code 0 (0x0)";
            //}
        }
    }
}
