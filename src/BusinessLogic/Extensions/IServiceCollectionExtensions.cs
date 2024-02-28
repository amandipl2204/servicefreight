using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceFreight.DataAccess.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            //services.AddScoped<ISampleRepository, SampleRepository>();

            return services;
        }
    }
}
