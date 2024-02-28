using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceFreight.BusinessLogic.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {

            //services.AddScoped<ISampleService, SampleService>();

            return services;
        }
    }
}
