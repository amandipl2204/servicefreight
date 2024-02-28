using Microsoft.Extensions.DependencyInjection;

namespace Utilities.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddUtilitiesDependencies(this IServiceCollection services)
        {
            //services.AddScoped<>();

            return services;
        }
    }
}
