using System;

namespace HandyToolsAndExtensions.Generic
{
    public class PerThreadSingleton<T> where T : class
    {
        [ThreadStatic]
        private static T instance;

        public static T Instance
        {
            get { return instance ?? (instance = Activator.CreateInstance<T>()); }
        }
    }
}