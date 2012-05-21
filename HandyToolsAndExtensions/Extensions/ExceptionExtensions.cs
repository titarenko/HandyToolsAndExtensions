using System;

namespace HandyToolsAndExtensions.Extensions
{
    public static class ExceptionExtensions
    {
        public static string Describe(this Exception exception)
        {
            var description = "{0}{1}".Fill(exception.Message, exception.StackTrace);

            if (exception.InnerException != null)
            {
                description += "{0}{1}".Fill(
                    Environment.NewLine, 
                    exception.InnerException.Describe());
            }
            
            return description;
        }
    }
}