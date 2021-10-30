using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreasuryChallenge.Configurations;

namespace TreasuryChallenge.Extensions
{
    public static class OptionsExtensions
    {
        public static IServiceCollection AddOptionsPattern(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileConfigurations>(configuration.GetSection(FileConfigurations.BaseConfig));

            return services;
        }
    }
}
