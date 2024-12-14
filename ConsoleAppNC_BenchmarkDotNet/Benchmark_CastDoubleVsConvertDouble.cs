using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using Newtonsoft.Json.Linq;
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
    public class Benchmark_CastDoubleVsConvertDouble
    {
        private readonly object _data = (ushort)445;

        [Benchmark(Baseline = true)]
        public double ConvertToDouble()
        {
            return Convert.ToDouble(_data);
        }

        [Benchmark]
        public double CastToDouble()
        {
            if (_data is double @double)
            {
                return @double;
            }
            else if (_data is byte @byte)
            {
                return @byte;
            }
            else if (_data is sbyte @sbyte)
            {
                return @sbyte;
            }
            else if (_data is ushort uint16)
            {
                return uint16;
            }
            else
            {
                //Console.WriteLine("ToDouble_UnhandledType Value: {1}, Type: {2}", value, value.GetType());
                return 0;
            }
        }
    }
}
