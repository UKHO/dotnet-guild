# Options Pattern in .NET Full Framework

There are many different ways to implement the Options pattern to work with your team's conventions. This example is simplified to point you in the right direction.

It is probably better to work with a static singleton. Injecting it is unlikely to have it read at startup for validation and will add additional work to unit testing.

Grouping of configuration items should fall out organically as development proceeds, into separate classes. Where suited to the domain, nesting may be appropriate.

## Sample solution

Full example in [FrameworkOptionsPatternExample solution](../src/FrameworkOptionsPatternExample), which includes a nested configuration.

Code examples tested with .NET 4.7.2 and C# 7.3.

## Example XML config

```csharp
public class XmlConfig : IConfig
{
    // Examples of nested configuration items
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
}
```

## Using the config class

```csharp
internal class Program
{
    private static void Main(string[] args)
    {
        // ...

        var myString = config.MyString;
        var loggingFilePath = config.LoggingConfiguration.FilePath;
        var loggingMaxLevel = config.LoggingConfiguration.MaximumLevel;

        // ...
    }
}
```

## Validating class from startup code

```csharp
public static void ValidateConfig(this IConfig config)
{
    JsonConvert.SerializeObject(config);
}
```
