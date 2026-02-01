using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostQueryService.Infrastructure.MsSql;

namespace PostQueryService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMsSql(configuration);
    }
}
