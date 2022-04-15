using System;

namespace ConsoleAppNC_BenchmarkDotNet.Models
{
    public class SubscriptionOrder
    {
        public long QOrderID { get; set; }
        public decimal Price { get; set; }
        public string Symbol { get; set; }
        public string SideDesc { get; set; }
        public string Status { get; set; }
        public string Text { get; set; }
        public string Side { get; set; }

        public decimal OrderQty { get { return CompleteQty; } }
        public decimal CompleteQty { get; set; }
        public long FractionalQty { get; set; }

        public string OriginatingUserDesc { get; set; }
        public string OrdType { get; set; }
        public decimal StopPx { get; set; }
        public string TimeInForce { get; set; }
        public DateTime TransactTime { get; set; }
        public string ClOrdID { get; set; }
        public string TifDesc { get; set; } // TIFDesc
        public string OrderTypeDesc { get; set; }
        public string StatusDesc { get; set; }

        public decimal AvgPx { get { return CompleteAvgPx; } }
        public decimal CompleteAvgPx { get; set; }
        public long FractionalAvgPx { get; set; }

        public decimal CumQty { get { return CompleteCumQty; } }
        public decimal CompleteCumQty { get; set; }
        public long FractionalCumQty { get; set; }

        public long WorkableQty { get; set; }

        public decimal LeavesQty { get { return CompleteLeaveQty; } }
        public decimal CompleteLeaveQty { get; set; }
        public long FractionalLeavesQty { get; set; }

        public string SymbolSfx { get; set; }
        public string SymbolWithoutSfx { get; set; }



        public string ID { get; set; }
        public string Destination { get; set; }
        public string Account { get; set; }
        public string Time { get; set; }
    }
}