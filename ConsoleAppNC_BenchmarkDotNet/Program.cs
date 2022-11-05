using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ConsoleAppNC_BenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //IDictionary<string, object> expandoAsDictionary = new ExpandoObject();
            //IDictionary<string, object> expandoAsDictionary = new Dictionary<string, object>();
            //expandoAsDictionary.Add("Prop 1", "StringProp");
            //expandoAsDictionary.Add("Prop 2", 1);
            //ExpandoObject result = (ExpandoObject)expandoAsDictionary;

            //var a = new Benchmark_ExpandoToDto2();
            //a.Global_Setup();
            //var b = a.Newtonsoft_Json_JsonConvert_SerializeObject();
            //var cd = a.Utf8Json_JsonSerializer_Serialize();
            //var d = a.System_Text_Json_JsonSerializer_Serialize();

            //new Benchmark_CastVsAs().CastAsWithError();
            //int total = 15;

            //Benchmark_ConnectionLocks.CheckTimeWithIndividualUsersLocks();
            //long sum = Enumerable
            //    .Range(1, total)
            //    .Select(_ => Benchmark_ConnectionLocks.CheckTimeWithIndividualUsersLocks())
            //    .Sum();
            //Console.WriteLine(sum / total);

            //long sum = Enumerable
            //    .Range(1, total)
            //    .Select(_ => Benchmark_ConnectionLocks.CheckTimeWithSingleLockForAllUsers())
            //    .Sum();
            //Console.WriteLine(sum / total);

            BenchmarkRunner.Run<Benchmark_IDictionaryVsExpandoObject>();

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
