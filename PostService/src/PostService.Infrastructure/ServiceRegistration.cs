using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostService.Infrastructure.LocalBlobService;
using PostService.Infrastructure.Orleans;

namespace PostService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddOrleans()
                .AddLocalBlobService(configuration);
    }
}
