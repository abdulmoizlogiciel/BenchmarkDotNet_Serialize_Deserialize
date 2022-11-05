using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_IDictionaryVsExpandoObject
    {
        [Benchmark(Baseline = true)]
        public void AddUsingDynamic()
        {
            dynamic expandoAsDynamic = new ExpandoObject();
            expandoAsDynamic.Prop1 = "StringProp";
            expandoAsDynamic.Prop2 = 1;

            ExpandoObject result = expandoAsDynamic;
        }

        [Benchmark]
        public void AddUsingDictionary()
        {
            IDictionary<string, object> expandoAsDictionary = new ExpandoObject();
            expandoAsDictionary.Add("Prop 1", "StringProp");
            expandoAsDictionary.Add("Prop 2", 1);

            ExpandoObject result = expandoAsDictionary as ExpandoObject;
        }
    }
}
