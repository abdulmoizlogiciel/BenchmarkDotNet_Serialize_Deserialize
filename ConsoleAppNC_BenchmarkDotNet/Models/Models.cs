using System;
using Utf8Json;

namespace ConsoleAppNC_BenchmarkDotNet
{
    public class LocatesBase
    {
        public string OrdType { get; set; }
        public string QuoteReqID { get; set; }
        public string OrdStatus { get; set; }
        public decimal OrderQty { get; set; }
        public decimal OfferSize { get; set; }
        public decimal CumQty { get; set; }
        public decimal AvgPx { get; set; }
        public string StatusDesc { get; set; }
        public long OrdRejReason { get; set; }
        public string TimeInForce { get; set; }
        public string Text { get; set; }
        public string ID { get; set; }
        public string Symbol { get; set; }
        public string SymbolSfx { get; set; }
        public DateTime TransactTime { get; set; }
        public string ClientID { get; set; }
        public string LocateType { get; set; }
        public string BoothID { get; set; }
        public string Account { get; set; }
        public string OriginatingUserDesc { get; set; }
        public decimal EtbQty { get; set; }
    }

    public class LocatesSystem : LocatesBase
    {
        [System.Text.Json.Serialization.JsonPropertyName("OfferPx")]
        public decimal OfferPxDecimal { get; set; }
        private long _OfferPx;
        [System.Text.Json.Serialization.JsonIgnore]
        public long OfferPx { get => _OfferPx; set { _OfferPx = Convert.ToInt64(OfferPxDecimal); } }

        [System.Text.Json.Serialization.JsonNumberHandling(System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString)]
        public long TransactionStatus { get; set; }
    }

    public class LocatesNewtonSoft : LocatesBase
    {
        public long OfferPx { get; set; }
        public long TransactionStatus { get; set; }
    }

    public class LocatesUtf8Json : LocatesBase
    {
        [System.Runtime.Serialization.DataMember(Name = "OfferPx")]
        public decimal OfferPxDecimal { get; set; }
        private long _OfferPx;
        [System.Runtime.Serialization.IgnoreDataMember]
        public long OfferPx { get => _OfferPx; set { _OfferPx = Convert.ToInt64(OfferPxDecimal); } }

        [System.Runtime.Serialization.DataMember(Name = "TransactionStatus")]
        public string TransactionStatusString { get; set; }
        private long _TransactionStatus;
        [System.Runtime.Serialization.IgnoreDataMember]
        public long TransactionStatus { get => _TransactionStatus; set { _TransactionStatus = int.Parse(TransactionStatusString); } }
    }


    public class LocatesCommon : LocatesBase
    {
        public decimal OfferPx { get; set; }
        public string TransactionStatus { get; set; }
    }

    //private long _TransactionStatus;
    //[Newtonsoft.Json.JsonIgnore]
    //[System.Runtime.Serialization.IgnoreDataMember]
    //[System.Text.Json.Serialization.JsonIgnore]
    //public long TransactionStatus { get { return _TransactionStatus; } set { _TransactionStatus = int.Parse(TransactionStatusString); } }

    //[System.Runtime.Serialization.DataMember(Name = "TransactionStatus")]
    //[Newtonsoft.Json.JsonProperty("TransactionStatus")]
    //[System.Text.Json.Serialization.JsonPropertyName("TransactionStatus")]
    //public string TransactionStatusString { get; set; }

    public sealed class JsonFormatterLong : IJsonFormatter<LocatesBase>
    {
        public LocatesBase Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadPropertyName() == "TransactionStatus")
            {
                return new LocatesBase();
            }
            return new LocatesBase();
            //return Utf8Json.Formatters.PrimitiveObjectFormatter.Default.Deserialize(ref reader, formatterResolver);
        }

        public void Serialize(ref JsonWriter writer, LocatesBase value, IJsonFormatterResolver formatterResolver)
        {
            //writer.WriteInt64(value);
            Utf8Json.Formatters.PrimitiveObjectFormatter.Default.Serialize(ref writer, value, formatterResolver);
            //writer.WriteString(value);
        }
    }
}
