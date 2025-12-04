using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ConsoleAppNC_BenchmarkDotNet.Benchmarks
{
    public static class Extensions
    {
        public static ExpandoObject ToExpando<T>(this T obj) where T : class, new()
        {
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var propertyInfo in typeof(T).GetProperties())
                expando.Add(propertyInfo.Name, propertyInfo.GetValue(obj));

            return expando as ExpandoObject;
        }

        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self) => self.Select((item, index) => (item, index));
    }
}
