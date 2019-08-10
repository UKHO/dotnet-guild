using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System;

namespace DiyConfigExample
{
    static class StaticConfigRoot
    {
        private static IConfigurationRoot _instance;

        public static IConfigurationRoot Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddAzureAppConfiguration(Environment.GetEnvironmentVariable("AZURE_APP_CONFIGURATION_CONNECTION_STRING"))
                        .Build();
                }

                return _instance;
            }
        }
    }
}