using System;
using System.Collections.Generic;

namespace ConsoleAppNC_BenchmarkDotNet
{
    public enum EnumMock
    {
        Value1 = 1,
        Value2 = 2,
        Value3 = 3,
        Value4 = 4,
    }
    public class MockDtoBase
    {
        public int INT { get; set; }
        public long LONG { get; set; }
        public double DOUBLE { get; set; }
        public string STRING { get; set; }
        public DateTime DATETIME { get; set; }
        public DateTimeOffset DATETIMEOFFSET { get; set; }
        public EnumMock ENUM { get; set; }
    }

    public class MockDto : MockDtoBase
    {
        public List<int> MYLIST1 { get; set; }
        public MockDtoBaseInternal MYOBJECT { get; set; }
        public List<MockDtoBase> MYLIST2 { get; set; }
    }

    public class MockDtoBaseInternal : MockDtoBase
    {
    }
}
