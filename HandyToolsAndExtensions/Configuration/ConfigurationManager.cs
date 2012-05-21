using System.Collections.Specialized;
using System.Configuration;
using HandyToolsAndExtensions.Extensions;
using Manager = System.Configuration.ConfigurationManager;

namespace HandyToolsAndExtensions.Configuration
{
    public static class ConfigurationManager
    {
        private static Context context;

        public static NameValueCollection AppSettings
        {
            get { return context.SafeGet(x => x.AppSettings) ?? Manager.AppSettings; }
        }

        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get { return context.SafeGet(x => x.ConnectionStrings) ?? Manager.ConnectionStrings; }
        }

        public static void SetContext(Context instance)
        {
            context = instance;
        }

        public class Context
        {
            public NameValueCollection AppSettings { get; set; }
            public ConnectionStringSettingsCollection ConnectionStrings { get; set; }

            public Context()
            {
                AppSettings = new NameValueCollection();
                ConnectionStrings = new ConnectionStringSettingsCollection();
            }
        }
    }
}