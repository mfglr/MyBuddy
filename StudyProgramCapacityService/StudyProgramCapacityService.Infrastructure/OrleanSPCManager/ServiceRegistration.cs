using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudyProgramCapacityService.Application;

namespace StudyProgramCapacityService.Infrastructure.OrleanSPCManager
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddOrleansCapacityManager(this IServiceCollection services) =>
            services
                .AddOrleansClient(x => x.UseLocalhostClustering(30002))
                .AddScoped<ISPCManager, OrleansSPCManager>();
    }
}
