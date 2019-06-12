using FrameworkOptionsPatternExample.Interfaces;
using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace FrameworkOptionsPatternExample.Config
{
    public class XmlConfig : IConfig
    {
        // Example of nested configuration items
        public ILoggingConfiguration LoggingConfiguration => new LoggingConfiguration();
        public IConnectionStringConfiguration ConnectionStringConfiguration => new ConnectionStringConfiguration();


        // Example of passing through a value from config
        public string MyString => ConfigurationManager.AppSettings["MyString"];

        // Example of returning a default if not value is specified
        public int MyNumber => int.TryParse(ConfigurationManager.AppSettings["MyNumber"], out var value) ? value : 9;

        // Example of returning a non-primitive type
        public Uri MyUri => new Uri(ConfigurationManager.AppSettings["MyUri"]);

        // Example of throwing an error if item is missing in the config file or it is not possible to parse the type
        public bool MyBoolThatMustBeDefined =>
            bool.TryParse(ConfigurationManager.AppSettings["MyBoolThatMustBeDefined"], out var val)
                ? val
                : throw new ConfigurationErrorsException("Could not parse your favourite boolean.");

        // Example of additional validation
        public string MyIpAddress
        {
            get
            {
                var ip = ConfigurationManager.AppSettings["MyIpAddress"];

                if (!string.IsNullOrEmpty(ip))
                {
                    string pattern =
                        @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

                    var regex = new Regex(pattern);
                    var match = regex.Match(ip);

                    if (match.Success)
                    {
                        return ip;
                    }
                }

                throw new ConfigurationErrorsException("Valid IP address not supplied for MyIpAddress.");
            }
        }

        // TODO example of transforming types from config

    }
}