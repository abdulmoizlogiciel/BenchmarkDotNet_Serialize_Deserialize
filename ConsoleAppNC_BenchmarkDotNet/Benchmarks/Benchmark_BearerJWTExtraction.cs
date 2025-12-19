using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using ConsoleAppNC_BenchmarkDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [Config(typeof(BenchmarkConfig))]
    public partial class Benchmark_BearerJWTExtraction
    {
        [GeneratedRegex(@"bearer\s+(\S+)", RegexOptions.IgnoreCase, matchTimeoutMilliseconds: 200)]
        private static partial Regex Regex_BearerPrefix();
        private static readonly Regex _regex = Regex_BearerPrefix();

        private const string _bearerPrefix = "Bearer ";

        private static readonly string _authorizationHeader = "       bearer       token12345678901234567890.token12345678901234567890.token12345678901234567890        ";

        [Benchmark(Description = "Span_Based_v1")]
        public string Span_Based()
        {
            ReadOnlySpan<char> span = _authorizationHeader.AsSpan().Trim();

            // Check if starts with "Bearer" (case-insensitive)
            if (!span.StartsWith(_bearerPrefix.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                return default;
            }

            // Extract token part and trim spaces
            ReadOnlySpan<char> tokenSpan = span.Slice(_bearerPrefix.Length).TrimStart();

            if (tokenSpan.IsEmpty || tokenSpan.IsWhiteSpace())
            {
                return default;
            }

            return tokenSpan.ToString();
        }

        [Benchmark(Description = "Span_Based_v2")]
        public string Span_BasedV2()
        {
            if (_authorizationHeader is null || _authorizationHeader.Length == 0)
            {
                return default;
            }

            ReadOnlySpan<char> span = _authorizationHeader.AsSpan().Trim();

            // Check if starts with "Bearer " (case-insensitive)
            if (!span.StartsWith(_bearerPrefix.AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                return default;
            }

            // Extract token part and trim spaces
            ReadOnlySpan<char> tokenSpan = span.Slice(_bearerPrefix.Length).TrimStart();

            if (tokenSpan.IsEmpty)
            {
                return default;
            }

            return tokenSpan.ToString();
        }

        [Benchmark(Description = "WithRegex", Baseline = true)]
        public string WithRegex()
        {
            var tokenMatch = _regex.Match(_authorizationHeader);
            if (tokenMatch.Success)
            {
                return tokenMatch.Groups[1].Value;
            }
            return default;
        }

        [Benchmark(Description = "OneLinerWithSplit")]
        public string OneLinerWithSplit()
        {
            // Quick and dirty, but allocates array
            string[] parts = _authorizationHeader.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (parts.Length < 2 || !parts[0].Equals("Bearer", StringComparison.OrdinalIgnoreCase))
            {
                return default;
            }

            return parts[1];
        }

        [Benchmark(Description = "SimpleStringMethod")]
        public string SimpleStringMethod()
        {
            // Trim and check prefix (case-insensitive)
            string trimmed = _authorizationHeader.Trim();
            if (!trimmed.StartsWith(_bearerPrefix, StringComparison.OrdinalIgnoreCase))
            {
                return default;
            }

            // Extract token, removing any extra spaces after "Bearer"
            string jwt = trimmed.Substring(_bearerPrefix.Length).TrimStart();

            // Validate token is not empty
            if (string.IsNullOrWhiteSpace(jwt))
            {
                return default;
            }

            return jwt;
        }

        [Benchmark(Description = "ManualParsing")]
        public string ManualParsing()
        {
            if (string.IsNullOrWhiteSpace(_authorizationHeader))
            {
                return null;
            }

            int startIndex = 0;
            int length = _authorizationHeader.Length;

            // Skip leading whitespace
            while (startIndex < length && char.IsWhiteSpace(_authorizationHeader[startIndex]))
            {
                startIndex++;
            }

            // Check for "Bearer" (case-insensitive)
            const string bearer = "bearer";
            if (startIndex + bearer.Length > length)
            {
                return null;
            }

            for (int i = 0; i < bearer.Length; i++)
            {
                if (char.ToLowerInvariant(_authorizationHeader[startIndex + i]) != bearer[i])
                {
                    return null;
                }
            }
            startIndex += bearer.Length;

            // Skip whitespace after "Bearer"
            while (startIndex < length && char.IsWhiteSpace(_authorizationHeader[startIndex]))
            {
                startIndex++;
            }

            // Find end of token (non-whitespace)
            int endIndex = startIndex;
            while (endIndex < length && !char.IsWhiteSpace(_authorizationHeader[endIndex]))
            {
                endIndex++;
            }

            if (endIndex == startIndex)
            {
                return null; // No token found
            }

            return _authorizationHeader.Substring(startIndex, endIndex - startIndex);
        }
    }
}
