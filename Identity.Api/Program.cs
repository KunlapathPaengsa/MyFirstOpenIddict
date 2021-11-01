using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                    config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true);
                    config.AddJsonFile($"swaggersettings.{context.HostingEnvironment.EnvironmentName}.json");
                    config.AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.RegisterAzureVault();
                    webBuilder.UseStartup<Startup>();
                }).ConfigureServices(config =>
                {
                    //config.AddHostedService<EFMigrateDatabaseService>();
                    //config.AddHostedService<AzureTableMigrateService>();
                   // config.AddHostedService<OpenIddictDefaultDataWorkerService>();
                });
    }
}
