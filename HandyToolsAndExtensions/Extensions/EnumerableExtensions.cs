using System;
using System.Collections.Generic;
using System.Linq;

namespace HandyToolsAndExtensions.Extensions
{
    public static class EnumerableExtensions
    {
        public static List<List<T>> Split<T>(this IEnumerable<T> list, int chunkSize)
        {
            return list
                .Select((x, i) => new {Index = i, Value = x})
                .GroupBy(x => x.Index/chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> enumerable, int timesCount)
        {
            while (timesCount-- > 0)
            {
                foreach (var item in enumerable)
                {
                    yield return item;
                }
            }
        }

        public static string Join<T>(this IEnumerable<T> enumerable, string separator)
        {
            return string.Join(separator ?? string.Empty, enumerable);
        }

        public static string Join<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Join(null);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }
    }
}