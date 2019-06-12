using FrameworkOptionsPatternExample.Config;

namespace FrameworkOptionsPatternExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Inject in production
            var config = new XmlConfig();

            // Very simple validation at startup rather than waiting for calls to entries
            config.ValidateConfig();

            var myString = config.MyString;
            var loggingFilePath = config.LoggingConfiguration.FilePath;
            var loggingMaxLevel = config.LoggingConfiguration.MaximumLevel;

            // ...
        }
    }
}