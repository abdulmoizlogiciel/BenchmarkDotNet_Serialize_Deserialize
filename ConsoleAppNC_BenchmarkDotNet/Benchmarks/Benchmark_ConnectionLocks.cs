using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public class Benchmark_ConnectionLocks
    {
        private static readonly List<string> s_users = Enumerable.Range(1, 10000).Select(x => $"user{x}").ToList();
        private static readonly IDictionary<string, object> s_locks = new Dictionary<string, object>();
        private static object GetLock(string username)
        {
            string key = username + "connection";
            if (s_locks.ContainsKey(key))
            {
                return s_locks[key];
            }
            lock (s_locks)
            {
                var lockValue = new object();
                s_locks.Add(key, lockValue);
                return lockValue;
            }
        }

        public static long CheckTimeWithIndividualUsersLocks()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.ForEach(s_users, user =>
            {
                var userLock = GetLock(user);
                lock (userLock)
                {
                    int a = 2;
                }
            });

            stopwatch.Stop();

            return stopwatch.ElapsedTicks;
        }


        private static readonly object s_singleLock = new object();
        public static long CheckTimeWithSingleLockForAllUsers()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.ForEach(s_users, user =>
            {
                lock (s_singleLock)
                {
                    int a = 2;
                }
            });

            stopwatch.Stop();
            return stopwatch.ElapsedTicks;
        }

        public Benchmark_ConnectionLocks()
        {
            CheckTimeWithIndividualUsersLocks();
        }


        [Benchmark(Baseline = true)]
        public void Bench_CheckTimeWithIndividualUsersLocks()
        {
            CheckTimeWithIndividualUsersLocks();
        }

        [Benchmark]
        public void Bench_CheckTimeWithSingleLockForAllUsers()
        {
            CheckTimeWithSingleLockForAllUsers();
        }
    }
}
