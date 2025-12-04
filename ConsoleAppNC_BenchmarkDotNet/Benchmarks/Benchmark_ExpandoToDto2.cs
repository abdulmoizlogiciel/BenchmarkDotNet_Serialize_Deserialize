using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System.Dynamic;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_ExpandoToDto2
    {
        private ExpandoObject Data;

        [GlobalSetup]
        public void Global_Setup()
        {
            string serialized = Util.ReadSerializedDataFromFileName("JsonWithNestedListOf35.json.txt");

            Data = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(serialized);
        }

        [Benchmark]
        public ResultDataObject<LocatesCommon> System_Text_Json_JsonSerializer_Serialize()
        {
            var serialized = System.Text.Json.JsonSerializer.Serialize(Data);
            return System.Text.Json.JsonSerializer.Deserialize<ResultDataObject<LocatesCommon>>(serialized);
        }

        [Benchmark(Baseline = true)]
        public ResultDataObject<LocatesCommon> Newtonsoft_Json_JsonConvert_SerializeObject()
        {
            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(Data);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDataObject<LocatesCommon>>(serialized);
        }

        [Benchmark]
        public ResultDataObject<LocatesCommon> Utf8Json_JsonSerializer_Serialize()
        {
            var serialized = Utf8Json.JsonSerializer.Serialize(Data);
            return Utf8Json.JsonSerializer.Deserialize<ResultDataObject<LocatesCommon>>(serialized);
        }
    }
}
