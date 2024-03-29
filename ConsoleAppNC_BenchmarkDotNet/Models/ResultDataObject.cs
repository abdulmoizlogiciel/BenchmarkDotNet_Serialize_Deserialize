﻿using System.Collections.Generic;

namespace ConsoleAppNC_BenchmarkDotNet.Models
{
    public class ResultDataObject<T> where T : class
    {
        public int? EventType { get; set; }
        public List<T> EventData { get; set; }
    }
}
