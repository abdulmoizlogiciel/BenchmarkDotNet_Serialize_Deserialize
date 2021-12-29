using BenchmarkDotNet.Running;
using System;

namespace ConsoleAppNC_BenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Benchmark_Serialization().Global_Setup();
            BenchmarkRunner.Run<Benchmark_Serialization>();

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
