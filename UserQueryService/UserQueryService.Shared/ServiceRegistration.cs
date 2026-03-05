using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserQueryService.Shared.MongoDB;

namespace UserQueryService.Shared
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMongoDB(configuration);
    }
}
