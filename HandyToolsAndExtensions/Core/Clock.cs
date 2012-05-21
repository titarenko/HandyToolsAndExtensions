using System;

namespace HandyToolsAndExtensions.Core
{
    public class Clock
    {
        private static DateTime? freezedTime;

        public static DateTime Now
        {
            get { return freezedTime.HasValue ? freezedTime.Value : DateTime.Now; }
        }

        public static void Freeze(DateTime time)
        {
            freezedTime = time;
        }

        public static void Release()
        {
            freezedTime = null;
        }
    }
}