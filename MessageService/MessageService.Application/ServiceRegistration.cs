using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MessageService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMediatR(x =>
                {
                    x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                    x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                })
                .AddAutoMapper(
                    x => x.LicenseKey = configuration["LuckPenny:LicenseKey"],
                    Assembly.GetExecutingAssembly()
                );
    }
}
