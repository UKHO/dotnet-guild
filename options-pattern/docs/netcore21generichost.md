# Options Pattern with a Generic Host service (Core 2.1)

If you are developing a service that runs from a console application and is not web focused, you might like to use the configuration services (including IOptions), as well as other services like a DI container and logging using the same conventions and packages as your ASP .NET Core 2.1 applications through WebHostBuilder. 

For this we utilise `IHost` and `HostBuilder`.

## Example

A console service could, for example, get all of its settings from Azure App Configuration (in preview at time of writing) and Azure Key Vault.

Note, this requires the managed service identity set for the app registration and permissions set for the developer running it.

```csharp
private static async Task Main(string[] args)
    {
        var builder = new HostBuilder()
            .UseEnvironment(Environment.GetEnvironmentVariable("ENVIRONMENT"))
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var keyVaultAddress = Environment.GetEnvironmentVariable("KEY_VAULT_ADDRESS");
                var azureAppConfConnectionString = Environment.GetEnvironmentVariable("AZURE_APP_CONFIGURATION_CONNECTION_STRING");

                var tokenProvider = new AzureServiceTokenProvider();
                var keyVaultClient =
                    new KeyVaultClient(
                        new KeyVaultClient.AuthenticationCallback(tokenProvider.KeyVaultTokenCallback));

                config.AddAzureAppConfiguration(azureAppConfConnectionString)
                        .AddAzureKeyVault(keyVaultAddress, keyVaultClient, new DefaultKeyVaultSecretManager())
                        .Build();
            })
            .ConfigureServices((hostingContext, services) =>
            {
                services.AddOptions<ExampleConfig>()
                    .Bind(hostingContext.Configuration.GetSection("MyConfig"));

                // services.AddSingleton<IHostedService, MyService>();
            })
            .UseConsoleLifetime();

        var host = builder.Build();

        using (host)
        {
            await host.RunAsync();
        }
    }
```

As with the other examples, you need to know the naming conventions. Here, we're binding our `ExampleConfig` class to the 'section' named *MyConfig* but there's numerous ways you can mix thing to suit the needs of your project.

In Azure App Configuration we just need to follow the convention for JSON subsections and prefix the property/key with *MyConfig* e.g.

> MyConfig:MySecretString = "my secret value"

This would bind to the property with the same name in the following POCO:

```csharp
public class ExampleConfig
{
    public string MyString { get; set; }
    public string MySecretString { get; set; }
}
```

Azure Key Vault only accepts dashes '-' and alphanumerics so here we use the convention of a double dash, which will be converted to a colon ':' e.g.

> MyConfig--MyString = "my string"

## Sample solution

Example code available in [Core21ConsoleAppOptionsExample solution](../src/Core21ConsoleAppOptionsExample).

Note the use of the following packages:

- Microsoft.Extensions.Hosting
- Microsoft.Extensions.Configuration.AzureKeyVault
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.AzureAppConfiguration (preview)
