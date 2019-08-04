# Rolling your own configuration for Core 2.1

There are scenarios where we might be without a host builder or anything else like a DI container out-of-the-box but still want the config providers and easy binding.

One such scenario is Page Object Models in a UI automation framework.

In Tamatoa, we opted for a static class that would build and persist an instance of `IConfigurationRoot` with all of the config providers we needed in the tests:

```csharp
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
                    .AddAzureAppConfiguration(Environment.GetEnvironmentVariable("AZURE_APP_CFG_CONN_STRING"))
                    .Build();
            }
            return _instance;
        }
    }
}

class MyPageConfig
{
    public Uri MyPageUrl { get; set; }
}
```

Using the `IConfigurationRoot` instance, we bind the `MyPageConfig` instance, `_config`, to the section 'urls'. 

```csharp
class MyPageObjectModel
{
    private readonly IWebDriver _driver;
    private readonly MyPageConfig _config = new MyPageConfig();

    public MyPageObjectModel(IWebDriver driver)
    {
        // ..
        var configRoot = ConfigurationRoot.Instance;
        configRoot.GetSection("urls").Bind(_config);
        // ..
    }

    public void NavigateTo() => _driver.Navigate().GoToUrl(_config.MyPageUrl);
}
```

In Azure App Configuration our URL would be stored in a key/value pair like so:

> urls:MyPageConfig = "http://www.foo.bar/"

Or in an appsettings.json file it would be:

```json
"urls": {
    "MyPageConfig": "http://www.foo.bar/",
}
```
