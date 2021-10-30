using Microsoft.Extensions.DependencyInjection;
using TreasuryChallenge.Controller;
using TreasuryChallenge.Domain.Interfaces;
using TreasuryChallenge.Services;

namespace TreasuryChallenge.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ITemplateFileServices, TemplateFileServices>();
            services.AddScoped<IWriteFileController, WriteFileController>();

            return services;
        }
    }
}
