using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            dynamic data = new ExpandoObject();

            data.INT = (int)321783498;
            data.LONG = (long)3217834983217834983;
            data.DOUBLE = (double)2.45678;
            data.STRING = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNyc2Etc2hhNTEyIiwidHlwIjoiSldUIn0.eyJzdWIiOiJzY290dCIsIk9UUCI6InpjeWlZY2U0eGlFeXpsRXBQeXYxNHVlMlQ2bTlGWk9EIiwiZXhwIjoxNjM4ODYzOTU2LCJpYXQiOjE2Mzg4NjM2NTYsIm5iZiI6MTYzODg2MzY1Nn0.hPhmN-3UnXkdPKHaVqHkraCVs-KWNtScbptln-19cxl7WDTzm8MaxiRyB5p1b5bQ3-6Lir5o4KoejNNc-glZ7at2CrgX6ekSiVVe1uIBibLRvHsr0xUWKRnh-6wwdHcb4WrHerVgU3KxLl6ATYW1eMFRSuGqxlHthWUzykunJN3oW92ZUGsFIhZyWY5pbSA5plt0z72_FUYPDhxDm0sYpN1LIgw0lMhx9N933TodP4j9oGUWpQRtWmqcoYUwBPW3z2x2HqzzTz1cDoB2ypFCoJY4sSlc3E3cHRTXGBiyCFHMFOy6KfS--ZEFSj-upxPnv57XS2pT_WcTSNi4OAOpdA";
            data.DATETIME = DateTime.Parse("2021-12-18T06:07:55.602Z");
            data.DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T06:07:55.602Z");

            data.MYLIST1 = new List<int> { 1, 2, 3, 4 };

            data.MYOBJECT = new MyObjectBase { INT = 98765, LONG = 7777777777777777, DOUBLE = 33.45678, STRING = "string base 2", DATETIME = DateTime.Parse("2021-12-18T05:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T09:07:55.602Z"), ENUM1 = Enum1.Value2 };
            //data.MYOBJECT = new MyObjectBase { INT = 98765, LONG = 7777777777777777, DOUBLE = 33.45678, STRING = "string base 2", DATETIME = DateTime.Parse("2021-12-18T05:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T09:07:55.602Z"), ENUM1 = Enum1.Value2 }.ToExpando();

            data.MYLIST2 = new List<MyObjectBase>
            {
                new MyObjectBase { INT = 98765, LONG = 7777777777777777, DOUBLE = 33.45678, DATETIME = DateTime.Parse("2021-12-18T05:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T09:07:55.602Z"), ENUM1 = Enum1.Value3, STRING = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNyc2Etc2hhNTEyIiwidHlwIjoiSldUIn0.eyJzdWIiOiJzY290dCIsIk9UUCI6InpjeWlZY2U0eGlFeXpsRXBQeXYxNHVlMlQ2bTlGWk9EIiwiZXhwIjoxNjM4ODY2NDQ1LCJpYXQiOjE2Mzg4NjYxNDUsIm5iZiI6MTYzODg2NjE0NX0.Iw1U6rSNvBYLZWtavPe3alc5J0HIRWaIFtiA0aAA7WShsxo-UkeHalU6uFOUVmNg5kbE84G96w96EPyiKW-NuQabHAQ6h7zRp7SQ2Y9WeQOitIwV-dZFb2qllHGcDLkAwn-abkXBAPItghjtdvlPawyZ8BahXhFDjgDS7wpTSJHrsFmowi8JqJR_6EGSkFsaoqb5gEbHhw-XQG7hLvJGEfKlPxtNsFCfRCgkKSnQ5V-a4rW8Zxesw95UQxBhQ0LFnwJTK2RYJ-R72sLZbbkR6FI3OQUAPn25BdbdWOX4nfDP1ecMOtzo5Cv7qLrpBy9EEonikAvo7q044C1X66XQwQ", },
                new MyObjectBase { INT = 12345, LONG = 8888888888888888, DOUBLE = 99.45678, DATETIME = DateTime.Parse("2021-12-18T04:07:55.602Z"), DATETIMEOFFSET = DateTimeOffset.Parse("2021-12-18T08:07:55.602Z"), ENUM1 = Enum1.Value4, STRING = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNyc2Etc2hhNTEyIiwidHlwIjoiSldUIn0.eyJzdWIiOiJzY290dCIsIk9UUCI6InpjeWlZY2U0eGlFeXpsRXBQeXYxNHVlMlQ2bTlGWk9EIiwiZXhwIjoxNjM4ODgxMDA5LCJpYXQiOjE2Mzg4ODA3MDksIm5iZiI6MTYzODg4MDcwOX0.dUo4K48w97-2hJa4WZesobgwWyR9Rwh7KNv4kHGdSCWUodg-nDLSIyVef_4C8M-fYpY2CWFwXrnzV1zMyNHFq9iJgXChbRFY7KCNpn9Sb0t93YmzH_Msu4oThFmRKTqgzJA6lBt8rdo_2Y-O3wtWqtJFd1AtFAYoc54NP1XLGZ6-T-O5EdDzB2xKnYbFrzCVGOOKvOqCjGpCKRjrgY1qrmmpkC17iwiWJBmgnn5INuviigKFVxZTk9x234dXewMPdvzWUR9hfxIMbCCYLlrcFnDFYL_VIDuixWZZpZddgzWZxm71bO6CATAav3LgDxxyywpRsG3aU4l4-qsKbdtXHg", },
            };
            //.Select(m => m.ToExpando());


            var test = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            var test2 = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(test);
        }
    }
}
