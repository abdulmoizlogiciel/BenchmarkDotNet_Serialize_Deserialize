using ConsoleAppNC_BenchmarkDotNet;
using ConsoleAppNC_BenchmarkDotNet.Benchmarks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private static MockDto GetData()
        {
            var data = new MockDto
            {
                INT = (int)321783498,
                LONG = (long)3217834983217834983,
                DOUBLE = (double)321783498321783498322222222222222.456781231231231,
                STRING = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNyc2Etc2hhNTEyIiwidHlwIjoiSldUIn0.eyJzdWIiOiJzY290dCIsIk9UUCI6InpjeWlZY2U0eGlFeXpsRXBQeXYxNHVlMlQ2bTlGWk9EIiwiZXhwIjoxNjM4ODYzOTU2LCJpYXQiOjE2Mzg4NjM2NTYsIm5iZiI6MTYzODg2MzY1Nn0.hPhmN-3UnXkdPKHaVqHkraCVs-KWNtScbptln-19cxl7WDTzm8MaxiRyB5p1b5bQ3-6Lir5o4KoejNNc-glZ7at2CrgX6ekSiVVe1uIBibLRvHsr0xUWKRnh-6wwdHcb4WrHerVgU3KxLl6ATYW1eMFRSuGqxlHthWUzykunJN3oW92ZUGsFIhZyWY5pbSA5plt0z72_FUYPDhxDm0sYpN1LIgw0lMhx9N933TodP4j9oGUWpQRtWmqcoYUwBPW3z2x2HqzzTz1cDoB2ypFCoJY4sSlc3E3cHRTXGBiyCFHMFOy6KfS--ZEFSj-upxPnv57XS2pT_WcTSNi4OAOpdA",
                DATETIME = DateTime.Parse("2021-12-18T06:07:55.602Z"),
                DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T06:07:55.602Z"),

                MYLIST1 = new List<int> { 1, 2, 3, 4 },
                MYOBJECT = new MockDtoBaseInternal { INT = 98765, LONG = 7777777777777777, DOUBLE = 33.45678, STRING = "string base 2", DATETIME = DateTime.Parse("2021-12-18T05:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T09:07:55.602Z"), ENUM = EnumMock.Value2 },
                MYLIST2 = new List<MockDtoBase>
                {
                    new MockDtoBase { INT = 321783497, LONG = 3217834983217834989, DOUBLE = 99.45678, DATETIME = DateTime.Parse("2021-12-18T04:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T08:07:55.602Z"), ENUM = EnumMock.Value4, STRING = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNyc2Etc2hhNTEyIiwidHlwIjoiSldUIn0.eyJzdWIiOiJzY290dCIsIk9UUCI6InpjeWlZY2U0eGlFeXpsRXBQeXYxNHVlMlQ2bTlGWk9EIiwiZXhwIjoxNjM4ODgxMDA5LCJpYXQiOjE2Mzg4ODA3MDksIm5iZiI6MTYzODg4MDcwOX0.dUo4K48w97-2hJa4WZesobgwWyR9Rwh7KNv4kHGdSCWUodg-nDLSIyVef_4C8M-fYpY2CWFwXrnzV1zMyNHFq9iJgXChbRFY7KCNpn9Sb0t93YmzH_Msu4oThFmRKTqgzJA6lBt8rdo_2Y-O3wtWqtJFd1AtFAYoc54NP1XLGZ6-T-O5EdDzB2xKnYbFrzCVGOOKvOqCjGpCKRjrgY1qrmmpkC17iwiWJBmgnn5INuviigKFVxZTk9x234dXewMPdvzWUR9hfxIMbCCYLlrcFnDFYL_VIDuixWZZpZddgzWZxm71bO6CATAav3LgDxxyywpRsG3aU4l4-qsKbdtXHg", },
                    new MockDtoBase { INT = 321783495, LONG = 3217834983217834988, DOUBLE = 33.45678, DATETIME = DateTime.Parse("2021-12-18T05:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T09:07:55.602Z"), ENUM = EnumMock.Value3, STRING = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNyc2Etc2hhNTEyIiwidHlwIjoiSldUIn0.eyJzdWIiOiJzY290dCIsIk9UUCI6InpjeWlZY2U0eGlFeXpsRXBQeXYxNHVlMlQ2bTlGWk9EIiwiZXhwIjoxNjM4ODY2NDQ1LCJpYXQiOjE2Mzg4NjYxNDUsIm5iZiI6MTYzODg2NjE0NX0.Iw1U6rSNvBYLZWtavPe3alc5J0HIRWaIFtiA0aAA7WShsxo-UkeHalU6uFOUVmNg5kbE84G96w96EPyiKW-NuQabHAQ6h7zRp7SQ2Y9WeQOitIwV-dZFb2qllHGcDLkAwn-abkXBAPItghjtdvlPawyZ8BahXhFDjgDS7wpTSJHrsFmowi8JqJR_6EGSkFsaoqb5gEbHhw-XQG7hLvJGEfKlPxtNsFCfRCgkKSnQ5V-a4rW8Zxesw95UQxBhQ0LFnwJTK2RYJ-R72sLZbbkR6FI3OQUAPn25BdbdWOX4nfDP1ecMOtzo5Cv7qLrpBy9EEonikAvo7q044C1X66XQwQ", },
                }
            };
            //.Select(m => m.ToExpando());

            return data;
        }

        private static MockDto Newtonsoft_Json_JsonConvert(object data)
        {
            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            var expandoObject = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(serialized);
            var expandoObjectSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(expandoObject);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<MockDto>(expandoObjectSerialized);
        }
        private static MockDto System_Text_Json_JsonSerializer(object data)
        {
            var serialized = System.Text.Json.JsonSerializer.Serialize(data);
            var expandoObject = System.Text.Json.JsonSerializer.Deserialize<ExpandoObject>(serialized);
            var expandoObjectSerialized = System.Text.Json.JsonSerializer.Serialize(expandoObject);
            return System.Text.Json.JsonSerializer.Deserialize<MockDto>(expandoObjectSerialized);
        }
        private static MockDto Utf8Json_JsonSerializer(object data)
        {
            var serialized = Utf8Json.JsonSerializer.Serialize(data);
            var expandoObject = Utf8Json.JsonSerializer.Deserialize<ExpandoObject>(serialized);
            var expandoObjectSerialized = Utf8Json.JsonSerializer.Serialize(expandoObject);
            var vvvv = Utf8Json.JsonSerializer.ToJsonString(expandoObject);
            return Utf8Json.JsonSerializer.Deserialize<MockDto>(serialized);
            //return Utf8Json.JsonSerializer.Deserialize<MyObject>(expandoObjectSerialized);
            return Utf8Json.JsonSerializer.Deserialize<MockDto>(vvvv);
        }


        [TestMethod]
        public void TestMethod_Newtonsoft_Json_JsonConvert()
        {
            var originalData = GetData();
            MockDto deserializedData = Newtonsoft_Json_JsonConvert(originalData);

            Assert.AreEqual(originalData.INT, deserializedData.INT);
            Assert.AreEqual(originalData.LONG, deserializedData.LONG);
            Assert.AreEqual(originalData.DOUBLE, deserializedData.DOUBLE);
            Assert.AreEqual(originalData.STRING, deserializedData.STRING);
            Assert.AreEqual(originalData.DATETIME, deserializedData.DATETIME);
            Assert.AreEqual(originalData.DATETIMEOFFSET, deserializedData.DATETIMEOFFSET);

            foreach (var (m1, index) in originalData.MYLIST1.WithIndex())
            {
                Assert.AreEqual(m1, deserializedData.MYLIST1[index]);
            }
            foreach (var (m2, index) in originalData.MYLIST2.WithIndex())
            {
                Assert.AreEqual(m2.DATETIME, deserializedData.MYLIST2[index].DATETIME);
                Assert.AreEqual(m2.DATETIMEOFFSET, deserializedData.MYLIST2[index].DATETIMEOFFSET);
                Assert.AreEqual(m2.DOUBLE, deserializedData.MYLIST2[index].DOUBLE);
                Assert.AreEqual(m2.ENUM, deserializedData.MYLIST2[index].ENUM);
                Assert.AreEqual(m2.INT, deserializedData.MYLIST2[index].INT);
                Assert.AreEqual(m2.LONG, deserializedData.MYLIST2[index].LONG);
                Assert.AreEqual(m2.STRING, deserializedData.MYLIST2[index].STRING);
            }
        }

        [TestMethod]
        public void TestMethod_System_Text_Json_JsonSerializer()
        {
            var originalData = GetData();
            MockDto deserializedData = System_Text_Json_JsonSerializer(originalData);

            Assert.AreEqual(originalData.INT, deserializedData.INT);
            Assert.AreEqual(originalData.LONG, deserializedData.LONG);
            Assert.AreEqual(originalData.DOUBLE, deserializedData.DOUBLE);
            Assert.AreEqual(originalData.STRING, deserializedData.STRING);
            Assert.AreEqual(originalData.DATETIME, deserializedData.DATETIME);
            Assert.AreEqual(originalData.DATETIMEOFFSET, deserializedData.DATETIMEOFFSET);

            foreach (var (m1, index) in originalData.MYLIST1.WithIndex())
            {
                Assert.AreEqual(m1, deserializedData.MYLIST1[index]);
            }
            foreach (var (m2, index) in originalData.MYLIST2.WithIndex())
            {
                Assert.AreEqual(m2.DATETIME, deserializedData.MYLIST2[index].DATETIME);
                Assert.AreEqual(m2.DATETIMEOFFSET, deserializedData.MYLIST2[index].DATETIMEOFFSET);
                Assert.AreEqual(m2.DOUBLE, deserializedData.MYLIST2[index].DOUBLE);
                Assert.AreEqual(m2.ENUM, deserializedData.MYLIST2[index].ENUM);
                Assert.AreEqual(m2.INT, deserializedData.MYLIST2[index].INT);
                Assert.AreEqual(m2.LONG, deserializedData.MYLIST2[index].LONG);
                Assert.AreEqual(m2.STRING, deserializedData.MYLIST2[index].STRING);
            }
        }

        [TestMethod]
        public void TestMethod_Utf8Json_JsonSerializer()
        {
            var originalData = GetData();
            MockDto deserializedData = Utf8Json_JsonSerializer(originalData);

            Assert.AreEqual(originalData.INT, deserializedData.INT);
            Assert.AreEqual(originalData.LONG, deserializedData.LONG);
            Assert.AreEqual(originalData.DOUBLE, deserializedData.DOUBLE);
            Assert.AreEqual(originalData.STRING, deserializedData.STRING);
            Assert.AreEqual(originalData.DATETIME, deserializedData.DATETIME);
            Assert.AreEqual(originalData.DATETIMEOFFSET, deserializedData.DATETIMEOFFSET);

            foreach (var (m1, index) in originalData.MYLIST1.WithIndex())
            {
                Assert.AreEqual(m1, deserializedData.MYLIST1[index]);
            }
            foreach (var (m2, index) in originalData.MYLIST2.WithIndex())
            {
                Assert.AreEqual(m2.DATETIME, deserializedData.MYLIST2[index].DATETIME);
                Assert.AreEqual(m2.DATETIMEOFFSET, deserializedData.MYLIST2[index].DATETIMEOFFSET);
                Assert.AreEqual(m2.DOUBLE, deserializedData.MYLIST2[index].DOUBLE);
                Assert.AreEqual(m2.ENUM, deserializedData.MYLIST2[index].ENUM);
                Assert.AreEqual(m2.INT, deserializedData.MYLIST2[index].INT);
                Assert.AreEqual(m2.LONG, deserializedData.MYLIST2[index].LONG);
                Assert.AreEqual(m2.STRING, deserializedData.MYLIST2[index].STRING);
            }
        }
    }
}
