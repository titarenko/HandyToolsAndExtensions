using System;

namespace HandyToolsAndExtensions.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsChildOf(this Type type, Type another)
        {
            return another.IsAssignableFrom(type);
        }
    }
}