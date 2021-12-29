using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_Deserialization3
    {
        public Benchmark_Deserialization3()
        {
            //var a = System_Text_Json_JsonSerializer_Deserialize();
            //var w = Newtonsoft_Json_JsonConvert_DeserializeObject();
            //var t = Utf8Json_JsonSerializer_Deserialize();
        }
        //private readonly string NewtonSerialized;
        //private readonly string SystemSerialized;
        //private readonly byte[] Utf8Serialized;
        //SystemSerialized = System.Text.Json.JsonSerializer.Serialize(Data);
        //NewtonSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(Data);
        //Utf8Serialized = Utf8Json.JsonSerializer.Serialize(Data);
        //public ResultDataObject<Locates> System_Text_Json_Deserialize() => System.Text.Json.JsonSerializer.Deserialize<ResultDataObject<Locates>>(Data, new System.Text.Json.JsonSerializerOptions { NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString });
        //public ResultDataObject<LocatesBase> Utf8Json_JsonSerializer_Deserialize() => Utf8Json.JsonSerializer.Deserialize<ResultDataObject<LocatesBase>>(Data, CompositeResolver.Create(new IJsonFormatter[] { new JsonFormatterLong() }, new[] { StandardResolver.Default }));
        //public MyObject System_Text_Json_Deserialize() => System.Text.Json.JsonSerializer.Deserialize<MyObject>(SystemSerialized);
        //public MyObject Newtonsoft_Json_JsonConvert_DeserializeObject() => Newtonsoft.Json.JsonConvert.DeserializeObject<MyObject>(NewtonSerialized);
        //public MyObject Utf8Json_JsonSerializer_Deserialize() => Utf8Json.JsonSerializer.Deserialize<MyObject>(Utf8Serialized);
    }
}
