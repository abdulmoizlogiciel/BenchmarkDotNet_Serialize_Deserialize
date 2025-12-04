using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public partial class Benchmark_ReplaceVsManualStringIteration
    {
        [GeneratedRegex("[\r\n]")]
        public static partial Regex MyRegex2();

        public static readonly string _longStringMsg = new string('A', 200) + "\r\n";
        public static readonly Regex _regex = new Regex("[\r\n]", RegexOptions.Compiled);
        public static readonly Regex _regex2 = MyRegex2();

        [Benchmark(Description = ".NET's Replace Char", Baseline = true)]
        public string ReplaceCharacter()
        {
            return _longStringMsg.Replace('\r', ' ').Replace('\n', ' ');
        }

        [Benchmark(Description = ".NET's Replace String")]
        public string ReplaceString()
        {
            return _longStringMsg.Replace("\r", "").Replace("\n", "");
        }

        //[Benchmark(Description = "StringBuilderManualLoop")]
        //public string StringBuilderManualLoop()
        //{
        //    var builder = new StringBuilder();
        //    for (int index = 0; index < _longStringMsg.Length; index++)
        //    {
        //        char currentChar = _longStringMsg[index];
        //        if (currentChar != '\r' && currentChar != '\n')
        //        {
        //            builder.Append(currentChar);
        //        }
        //    }
        //    return builder.ToString();
        //}

        [Benchmark(Description = "RegexReplace")]
        public string RegexReplace()
        {
            return _regex.Replace(_longStringMsg, string.Empty);
        }

        [Benchmark(Description = "RegexReplace Generated Regex")]
        public string RegexReplaceGeneratedRegex()
        {
            return _regex2.Replace(_longStringMsg, string.Empty);
        }
    }
}
