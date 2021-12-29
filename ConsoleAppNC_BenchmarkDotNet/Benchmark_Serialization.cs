using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System.Dynamic;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_Serialization
    {
        private ExpandoObject Data;

        [GlobalSetup]
        public void Global_Setup()
        {
            string serialized = Util.ReadSerializedDataByFileName("JsonWithNestedListOf1000.txt");
            Data = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(serialized);
        }

        [Benchmark]
        public string System_Text_Json_JsonSerializer_Serialize() => System.Text.Json.JsonSerializer.Serialize(Data);

        [Benchmark(Baseline = true)]
        public string Newtonsoft_Json_JsonConvert_SerializeObject() => Newtonsoft.Json.JsonConvert.SerializeObject(Data);

        [Benchmark]
        public byte[] Utf8Json_JsonSerializer_Serialize() => Utf8Json.JsonSerializer.Serialize(Data);
    }
}
