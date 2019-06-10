# Wrapping Calls to C# Configuration with the Options Pattern

This guide covers generally, the rationale for the options pattern. It also provides examples for:

- how to implement for .NET full framework applications.
- NET Core has support for the options pattern out of the box and we will extend the guide to cover this shortly.
  
## Benefits

**Less string literals**: No repeating of string literals (keys) throughout code, which aids refactoring tools and reduces typing errors.

**Type-safety**: A single location to parse string values to strongly-typed properties (the single benefit of using schema languages to enforce type-safety would not give good ROI).

**Default values**: A single location to return default values when required.

**Validation of values**: A single location to catch missing config entries, misspelled keys or invalid values/types.

**Fail-fast**: Straightforward to read and verify all values at application startup.

**Decoupled**: Code is decoupled from config file markup type.

**Grouped configs**: Group config classes into related settings in order to adhere to **Interface Segregation Principle** and **Separation of Concerns** - that application classes only depend on settings that they use and these settings are decoupled between parts of the applications.

**Nested configs**: Organise config classes via nesting.

**Unit testing**: No need to mirror app.config in the tests project or employ other magic. You can now mock calls to config easily.

## .NET Full Framework Implementation Example

There are many different ways to implement the Options pattern to work with your team's conventions. This example is overly simplified to point you in the right direction.

It is probably better to work with a static singleton. Injecting it is unlikely to have it read at startup for validation and will add additional work to unit testing.

Grouping of configuration items should fall out organically as development proceeds, into separate classes. Where suited to the domain, nesting may be appropriate.

### .NET Full Framework Example Snippets

Full example in OptionsPatternExamples solution, which includes the nested configurations.

Code examples tested with .NET 4.7.1 and C# 7.3.

#### Example XML Config

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

#### Example Use of Config Class

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

#### Example Validating Class From Startup Code

```csharp
public static void ValidateConfig(this IConfig config)
{
    JsonConvert.SerializeObject(config);
}
```

## ASP .NET Core Example

Coming soon.
