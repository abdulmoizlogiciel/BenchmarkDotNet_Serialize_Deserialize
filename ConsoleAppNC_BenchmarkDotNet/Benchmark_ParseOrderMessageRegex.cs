﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System.Text.RegularExpressions;

namespace ConsoleAppNC_BenchmarkDotNet
{

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_ParseOrderMessageRegex
    {
        string strResponse = "1=3|2=4|3=Locate not available for the requested stock.|";

        [Benchmark(Baseline = true)]
        public void WithCompile()
        {
            
            string regExKeyValue = string.Format("(?:(?:(?:(?:([\"'])(?<Key>(?:(?=(\\\\?))\\2.)*?)\\1)|(?<Key>[^\\\"{0}{1}]*))(\\=)(?:(?:([\"'])(?<Value>(?:(?=(\\\\?))\\2.)*?)\\1)|(?<Value>[^\\\"{1}]*)))({1}|$))+",
                     Regex.Escape("="), Regex.Escape("|"));
            Regex keyValueSplit = new Regex(regExKeyValue, RegexOptions.Compiled);
            var match = keyValueSplit.Match(strResponse);
        }

        [Benchmark]
        public void WithOutCompile()
        {
            string regExKeyValue = string.Format("(?:(?:(?:(?:([\"'])(?<Key>(?:(?=(\\\\?))\\2.)*?)\\1)|(?<Key>[^\\\"{0}{1}]*))(\\=)(?:(?:([\"'])(?<Value>(?:(?=(\\\\?))\\2.)*?)\\1)|(?<Value>[^\\\"{1}]*)))({1}|$))+",
                     Regex.Escape("="), Regex.Escape("|"));
            Regex keyValueSplit = new Regex(regExKeyValue);
            var match = keyValueSplit.Match(strResponse);
        }

        
    }
}
