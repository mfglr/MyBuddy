using CommentQueryService.Application.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CommentQueryService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuraiton)
        {
            return services
                .AddSingleton<CommentResponseMapper>()
                .AddMediatR(
                    cfg =>
                    {
                        cfg.LicenseKey = configuraiton.GetSection("LuckPenny:LicenseKey").Value;
                        cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    }
                );
        }
    }
}
