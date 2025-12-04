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
    public class Benchmark_ExpandoToDto1
    {
        private ExpandoObject Data;

        [GlobalSetup]
        public void Global_Setup()
        {
            string serialized = Util.ReadSerializedDataFromFileName("SubscriptionOrdersCount34.json.txt");

            Data = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(serialized);
        }

        [Benchmark]
        public ResultDataObject<SubscriptionOrder> System_Text_Json_JsonSerializer_Serialize()
        {
            var serialized = System.Text.Json.JsonSerializer.Serialize(Data);
            return System.Text.Json.JsonSerializer.Deserialize<ResultDataObject<SubscriptionOrder>>(serialized);
        }

        [Benchmark(Baseline = true)]
        public ResultDataObject<SubscriptionOrder> Newtonsoft_Json_JsonConvert_SerializeObject()
        {
            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(Data);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ResultDataObject<SubscriptionOrder>>(serialized);
        }

        [Benchmark]
        public ResultDataObject<SubscriptionOrder> Utf8Json_JsonSerializer_Serialize()
        {
            var serialized = Utf8Json.JsonSerializer.Serialize(Data);
            return Utf8Json.JsonSerializer.Deserialize<ResultDataObject<SubscriptionOrder>>(serialized);
        }
    }
}
