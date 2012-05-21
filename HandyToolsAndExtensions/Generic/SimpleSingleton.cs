using System;

namespace HandyToolsAndExtensions.Generic
{
    public class SimpleSingleton<T> where T : class
    {
        private static T instance;

        public static T Instance
        {
            get { return instance ?? (instance = Activator.CreateInstance<T>()); }
        }
    }
}