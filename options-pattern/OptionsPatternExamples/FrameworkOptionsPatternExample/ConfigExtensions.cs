using FrameworkOptionsPatternExample.Interfaces;

using Newtonsoft.Json;

namespace FrameworkOptionsPatternExample
{
    public static class ConfigExtensions
    {
        // Simple example which blows up on first failed value
        public static void ValidateConfig(this IConfig config)
        {
            JsonConvert.SerializeObject(config);
        }
    }
}