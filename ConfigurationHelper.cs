
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAdvert.SearchWorker
{
    public static class ConfigurationHelper
    {
        private static IConfiguration configuration = null;
        public static IConfiguration Instance
        {

            get
            {
                if (configuration == null)
                {
                    configuration = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();
                }
                return configuration;

            }
            set {; }
        }
    }
}
