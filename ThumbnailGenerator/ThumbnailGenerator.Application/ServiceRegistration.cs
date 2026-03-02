using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ThumbnailGenerator.Application.UseCases.GenerateThumbnails;

namespace ThumbnailGenerator.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<GenerateThumbnailsMapper>()
                .AddScoped<TempDirectoryManager>()
                .AddMediatR(
                    cfg =>
                    {
                        cfg.LicenseKey = configuration["LuckPenny:LicenseKey"];
                        cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    }
                );
    }
}
