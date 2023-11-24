using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Threading;

namespace ConsoleAppNC_BenchmarkDotNet
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_LockVsManualReset
    {
        public static ManualResetEvent _lockManualReset = new ManualResetEvent(true);
        public static ManualResetEventSlim _lockManualResetSlim = new ManualResetEventSlim(true);
        public static object _lock = new object();

        [Benchmark(Baseline = true)]
        public void NormalLock()
        {
            lock (_lock)
            {
                _ = "ManualReset".Equals("Lock", StringComparison.OrdinalIgnoreCase);
            }
        }

        [Benchmark]
        public void ManualResetEventSlim_TrueState()
        {
            _lockManualResetSlim.Wait();
            _ = "ManualReset".Equals("Lock", StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark]
        public void ManualResetEvent_TrueState()
        {
            _lockManualReset.WaitOne();
            _ = "ManualReset".Equals("Lock", StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark]
        public void WithoutAnyLock()
        {
            _ = "ManualReset".Equals("Lock", StringComparison.OrdinalIgnoreCase);
        }
    }
}
