using System;

namespace HandyToolsAndExtensions.Extensions
{
    public static class CommonExtensions
    {
        public static T SafeGet<TModel, T>(this TModel model, Func<TModel, T> selector)
        {
            return model == null ? default(T) : selector(model);
        }
    }
}