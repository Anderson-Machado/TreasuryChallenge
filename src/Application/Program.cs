using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using TreasuryChallenge.Extensions;
using TreasuryChallenge.Worker;

namespace TreasuryChallenge
{
    class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IConfiguration GetConfiguration(string[] args, IHostEnvironment environment)
        {
            return new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
               .Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var env = hostContext.HostingEnvironment;
                    var config = GetConfiguration(args, env);
                    services.AddDependencyInjection()
                            .AddOptionsPattern(config);
                    services.AddHostedService<FileWorker>();
                });

    }
}