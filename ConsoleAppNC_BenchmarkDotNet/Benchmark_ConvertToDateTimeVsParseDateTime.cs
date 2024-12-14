using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class ConvertToDateTimeVsParseDateTime
    {
        private readonly object _dataUnHappy = null;
        private readonly object _data = "2023-06-29";

        [Benchmark(Baseline = true)]
        public DateTime ConvertToDateTime()
        {
            return Convert.ToDateTime(_data);
        }

        //[Benchmark]
        //public DateTime ParseExactDateTime()
        //{
        //    if (DateTime.TryParseExact(_data as string, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
        //    {
        //        return result;
        //    }
        //    return new DateTime(0);
        //}

        //[Benchmark]
        //public DateTime ParseExactDateTime()
        //{
        //    if (_data is string dateString && dateString.Length != 0)
        //    {
        //        int year = int.Parse(dateString[..4]);
        //        int month = int.Parse(dateString.Substring(5, 2));
        //        int day = int.Parse(dateString.Substring(8, 2));

        //        return new DateTime(year, month, day);
        //    }
        //    return new DateTime(0);
        //}

        [Benchmark]
        public DateTime ParseExactDateTime()
        {
            if (_data is string dateString && dateString.Length != 0)
            {
                int year = (dateString[0] - '0') * 1000 + (dateString[1] - '0') * 100 + (dateString[2] - '0') * 10 + (dateString[3] - '0');
                int month = (dateString[5] - '0') * 10 + (dateString[6] - '0');
                int day = (dateString[8] - '0') * 10 + (dateString[9] - '0');

                return new DateTime(year, month, day);
            }
            return new DateTime(0);
        }

        //[Benchmark]
        //public DateTime ParseExactSpanDateTime()
        //{
        //    if (_data is string dateString && dateString.Length != 0)
        //    {
        //        var arr = dateString.ToCharArray();
        //        int year = int.Parse(new ReadOnlySpan<char>(arr, 0, 4));
        //        int month = int.Parse(new ReadOnlySpan<char>(arr, 5, 2));
        //        int day = int.Parse(new ReadOnlySpan<char>(arr, 8, 2)); 

        //        return new DateTime(year, month, day);
        //    }
        //    return new DateTime(0);
        //}

        [Benchmark]
        public DateTime ParseDateTime()
        {
            return DateTime.Parse(_data as string);
        }

        //[Benchmark]
        //public DateTime ParseDateTime_NullCheck_HappyCase()
        //{
        //    if (_data is string date && date.Length != 0)
        //    {
        //        return DateTime.Parse(date);
        //    }
        //    return new DateTime(0);
        //}

        //[Benchmark]
        //public DateTime ParseDateTime_NullCheck_UnHappyCase()
        //{
        //    if (_dataUnHappy is string date && date.Length != 0)
        //    {
        //        return DateTime.Parse(date);
        //    }
        //    return new DateTime(0);
        //}
    }
}
