using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace HandyToolsAndExtensions.Extensions
{
    public static class StringExtensions
    {
        public static string Fill(this string format, params object[] args)
        {
            return String.Format(format, args);
        }

        public static bool IsEmpty(this string @string)
        {
            return String.IsNullOrWhiteSpace(@string);
        }

        public static bool IsNullOrEmpty(this string @string)
        {
            return String.IsNullOrEmpty(@string);
        }

        public static long ToLong(this string @string)
        {
            return Int64.Parse(@string);
        }

        public static double ToDouble(this string @string)
        {
            return Double.Parse(@string);
        }

        public static T ToEnum<T>(this string @string)
        {
            return (T)(@string.IsNullOrEmpty() ? default(T) : Enum.Parse(typeof(T), @string.Replace(" ", ""), true));
        }

        public static DateTime ToDateTime(this string @string)
        {
            return DateTime.ParseExact(@string, "dd/mm/yyyy", CultureInfo.InvariantCulture);
        }

        public static IEnumerable<string> SplitLines(this string @string)
        {
            return @string.Split('\n');
        }

        public static string Remove(this string @string, params string[] substrings)
        {
            if (substrings.Length > 1)
            {
                var builder = new StringBuilder(@string);

                foreach (var substring in substrings)
                {
                    builder.Replace(substring, String.Empty);
                }

                return builder.ToString();
            }
            else
            {
                return @string.Replace(substrings[0], String.Empty);
            }
        }

        public static bool EndsWithAny(this string @string, params string[] endings)
        {
            return endings.Any(@string.EndsWith);
        }

        public static bool ContainsAny(this string @string, params string[] substrings)
        {
            return @string.ContainsAny(substrings as IEnumerable<string>);
        }

        public static bool ContainsAny(this string @string, IEnumerable<string> substrings)
        {
            return substrings.Any(@string.Contains);
        }
    }
}