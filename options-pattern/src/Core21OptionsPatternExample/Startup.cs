using Core21OptionsPatternExample.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace Core21OptionsPatternExample
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _logger = logger;

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddOptions<MySettings>()
                .Bind(Configuration.GetSection("MyJsonSection"))
                .Bind(Configuration.GetSection("MySecretSection"))
                .Bind(Configuration.GetSection("MyEnvVarsSection"))
                .Configure(o => { o.MyString = "Value added via delegate"; })
                .PostConfigure(o =>
                {
                    var errors = string.Join(",", o.ValidateDataAnnotations().Concat(o.Validate()));
                    if (errors.Any())
                    {
                        var message = $"Found configuration error(s) in {o.GetType().Name}: {errors}";
                        _logger.LogError(message);
                        throw new ApplicationException(message);
                    }
                });

            // Eager validation of MySettings at startup via a cheeky Service Locator
            using (var sp = services.BuildServiceProvider())
            {
                var dummy = sp.GetService<IOptions<MySettings>>().Value;
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
