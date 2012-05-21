using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HandyToolsAndExtensions.Extensions
{
    public static class StringExtensions
    {
        public static string With(this string format, params object[] args)
        {
            return String.Format(format, args);
        }

        public static bool IsEmpty(this string @string)
        {
            return String.IsNullOrWhiteSpace(@string);
        }

        public static long ToLong(this string @string)
        {
            return long.Parse(@string);
        }

        public static double ToDouble(this string @string)
        {
            return double.Parse(@string);
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
                    builder.Replace(substring, string.Empty);
                }

                return builder.ToString();
            }
            else
            {
                return @string.Replace(substrings[0], string.Empty);
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