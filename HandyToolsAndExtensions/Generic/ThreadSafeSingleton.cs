using System;

namespace HandyToolsAndExtensions.Generic
{
    public class ThreadSafeSingleton<T> where T : class
    {
        private static volatile T instance;

        private static readonly object root = new object();
        
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (root)
                    {
                        if (instance == null)
                        {
                            instance = Activator.CreateInstance<T>();
                        }
                    }
                }

                return instance;
            }
        }
    }
}