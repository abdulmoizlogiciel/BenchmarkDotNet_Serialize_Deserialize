using BenchmarkDotNet.Running;
using System;

namespace ConsoleAppNC_BenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkXorVsNot>();

            //new Benchmark_Serialization().Global_Setup();
            //BenchmarkRunner.Run<BenchmarkArrayVsList>();

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
