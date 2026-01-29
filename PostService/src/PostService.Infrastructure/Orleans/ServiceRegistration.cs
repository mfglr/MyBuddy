using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans.Hosting;

namespace PostService.Infrastructure.Orleans
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddOrleans(this IServiceCollection services) =>
            services
                .AddOrleansClient(c => c.UseLocalhostClustering());
    }
}
