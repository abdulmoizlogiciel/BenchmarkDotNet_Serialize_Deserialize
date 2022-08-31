using BenchmarkDotNet.Running;
using System;

namespace ConsoleAppNC_BenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new Benchmark_ExpandoToDto2();
            //a.Global_Setup();
            //var b = a.Newtonsoft_Json_JsonConvert_SerializeObject();
            //var cd = a.Utf8Json_JsonSerializer_Serialize();
            //var d = a.System_Text_Json_JsonSerializer_Serialize();

            //new Benchmark_CastVsAs().CastAsWithError();

            BenchmarkRunner.Run<Benchmark_ParseOrderMessageRegexCached>();

            //new Benchmark_Serialization().Global_Setup();
            //BenchmarkRunner.Run<Benchmark_Serialization>();

            //BenchmarkRunner.Run<BenchmarkXorVsNot>();

            //BenchmarkRunner.Run<Benchmark_Serialization2>();
            //new Benchmark_Serialization2();

            //BenchmarkRunner.Run<Benchmark_Serialization3>();
            //new Benchmark_Serialization3();

            //BenchmarkRunner.Run<Benchmark_Deserialization1>();
            //new Benchmark_Deserialization1();


            //BenchmarkRunner.Run<Benchmark_Deserialization2>();
            //new Benchmark_Deserialization2();

            Console.ReadLine();
        }
    }
}
