using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_IE
    {
        private static readonly JsonSerializerOptions SJsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };

        [Benchmark(Description = "SerializeToUtf8Bytes")]
        public void SerializeToUtf8Bytes()
        {
            var obj = new MarketL1Data();
            var bytes = JsonSerializer.SerializeToUtf8Bytes(obj, SJsonSerializerOptions);
            var arraySegment = new ArraySegment<byte>(bytes);
        }

        [Benchmark(Description = "SerializeToString_Then_Encoding_UTF8_GetBytes")]
        public void SerializeToString_Then_Encoding_UTF8_GetBytes()
        {
            var obj = new MarketL1Data();
            var bytes = JsonSerializer.Serialize(obj, SJsonSerializerOptions);
            var arraySegment = new ArraySegment<byte>(Encoding.UTF8.GetBytes(bytes));
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
