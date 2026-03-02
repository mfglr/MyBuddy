using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VideoTranscoder.Application.UseCases.TranscodeVideo;

namespace VideoTranscoder.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<TranscodeVideoMapper>()
                .AddScoped<TempDirectoryManager>()
                .AddMediatR(cfg =>
                {
                    cfg.LicenseKey = configuration["LuckPenny:LicenseKey"];
                    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                });
    }
}
