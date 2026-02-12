using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PostLikeService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddAutoMapper(
                    x => x.LicenseKey = configuration["LuckPenny:LicenseKey"],
                    Assembly.GetExecutingAssembly()
                )
                .AddMediatR(
                    x =>
                    {
                        x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                        x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    }
                );
    }
}
