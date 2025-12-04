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
    public class Benchmark_Deserialization1
    {
        private readonly string DataJsonString;
        private readonly byte[] DataByteArray;

        public Benchmark_Deserialization1()
        {
            DataJsonString = Util.ReadSerializedDataFromFileName("JsonWithNestedListOf35.json.txt");

            var expando = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(DataJsonString);
            DataByteArray = Utf8Json.JsonSerializer.Serialize(expando);
        }


        [Benchmark(Description = "Sytem.Text Deserialization from JSON string")]
        public ResultDataObject<LocatesCommon> System_Text_Json_JsonSerializer_Deserialize() => System.Text.Json.JsonSerializer.Deserialize<ResultDataObject<LocatesCommon>>(DataJsonString);

        [Benchmark(Description = "Newtonsoft Deserialization from JSON string", Baseline = true)]
        public ResultDataObject<LocatesCommon> Newtonsoft_Json_JsonConvert_DeserializeObject() => Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDataObject<LocatesCommon>>(DataJsonString);

        [Benchmark(Description = "Utf8       Deserialization from JSON string")]
        public ResultDataObject<LocatesCommon> Utf8Json_JsonSerializer_Deserialize() => Utf8Json.JsonSerializer.Deserialize<ResultDataObject<LocatesCommon>>(DataJsonString);

        [Benchmark(Description = "Utf8       Deserialization from      byte[]")]
        public ResultDataObject<LocatesCommon> Utf8Json_JsonSerializer_Deserialize_ByteArray() => Utf8Json.JsonSerializer.Deserialize<ResultDataObject<LocatesCommon>>(DataByteArray);
    }
}
