using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_SerializeToStringVsSerializeToUtf8Bytes
    {
        private static readonly MarketL1Data SDataObj = new MarketL1Data();
        private static readonly JsonSerializerOptions SJsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };

        [Benchmark(Description = "SerializeToUtf8Bytes")]
        public ArraySegment<byte> SerializeToUtf8Bytes()
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(SDataObj, SJsonSerializerOptions);
            return new ArraySegment<byte>(bytes);
        }

        [Benchmark(Description = "SerializeToString_Then_Encoding_Default_GetBytes", Baseline = true)]
        public ArraySegment<byte> SerializeToString_Then_Encoding_Default_GetBytes()
        {
            var bytes = JsonSerializer.Serialize(SDataObj, SJsonSerializerOptions);
            return new ArraySegment<byte>(Encoding.Default.GetBytes(bytes));
        }
    }


    public class MarketL1Data
    {
        public List<double> Ask { get; set; }
        public long AskSize { get; set; }
        public ulong AskTime { get; set; }
        public string AskExchange { get; set; }
        public List<double> Bid { get; set; }
        public long BidSize { get; set; }
        public ulong BidTime { get; set; }
        public string BidExchange { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double High { get; set; }
        public long HighTime { get; set; }
        public string HighExchange { get; set; }
        public double Low { get; set; }
        public long LowTime { get; set; }
        public string LowExchange { get; set; }
        public double QuoteLotSize { get; set; }
        public long Volume { get; set; }
        public string TradingStatus { get; set; }
        public List<double> Change { get; set; }
        public List<double> PercentChange { get; set; }
        public List<double> Last { get; set; }
        public long LastSize { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public List<double> PrePostMarketTrade { get; set; }
        public long PrePostMarketTradeSize { get; set; }
        public double LotSize { get; set; }
    }
}
