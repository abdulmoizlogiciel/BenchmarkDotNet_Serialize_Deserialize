using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System.Text.RegularExpressions;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_ParseOrderMessageRegexCached
    {
        static string strResponse = "1=3|2=4|3=Locate not available for the requested stock.|";
        static string regExKeyValue = string.Format("(?:(?:(?:(?:([\"'])(?<Key>(?:(?=(\\\\?))\\2.)*?)\\1)|(?<Key>[^\\\"{0}{1}]*))(\\=)(?:(?:([\"'])(?<Value>(?:(?=(\\\\?))\\2.)*?)\\1)|(?<Value>[^\\\"{1}]*)))({1}|$))+",
        Regex.Escape("="), Regex.Escape("|"));
        static Regex compiled = new Regex(regExKeyValue, RegexOptions.Compiled);
        static Regex noncompiled = new Regex(regExKeyValue);

        [Benchmark(Baseline = true)]
        public void WithCompile()
        {

            var match = compiled.Match(strResponse);
        }

        [Benchmark]
        public void WithOutCompile()
        {
            var match = noncompiled.Match(strResponse);
        }


    }
}