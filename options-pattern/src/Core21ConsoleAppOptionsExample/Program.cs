using Core21ConsoleAppOptionsExample.Config;

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Core21ConsoleAppOptionsExample
{
    internal class Program
    {
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
                        .Bind(hostingContext.Configuration.GetSection("ExampleConfig"));

                    // services.AddSingleton<IHostedService, MyService>();
                })
                .UseConsoleLifetime();

            var host = builder.Build();

            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
