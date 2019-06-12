using FrameworkOptionsPatternExample.Interfaces;
using System.Configuration;

namespace FrameworkOptionsPatternExample.Config
{
    public class LoggingConfiguration : ILoggingConfiguration
    {
        public string MaximumLevel => ConfigurationManager.AppSettings["Logging:MaximumLevel"];

        public string FilePath => ConfigurationManager.AppSettings["Logging:FilePath"];

        public string MinimumLevel => ConfigurationManager.AppSettings["Logging:MinimumLevel"];

        public string DatePattern => ConfigurationManager.AppSettings["Logging:DatePattern"];
    }
}