using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.Application.UseCases.CreateMedia;

namespace UserService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<MediaTypeExtractor>()
                .AddAutoMapper(
                    cfg => cfg.LicenseKey = configuration.GetSection("LuckPenny:LicenseKey").Value,
                    Assembly.GetExecutingAssembly()
                )
                .AddMediatR(
                    cfg => {
                        cfg.LicenseKey = configuration.GetSection("LuckPenny:LicenseKey").Value;
                        cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                    }
                );
    }
}
