using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostQueryService.Application.UseCases;
using PostQueryService.Application.UseCases.UpsertPost;
using PostQueryService.Application.UseCases.UpsertUser;
using System.Reflection;

namespace PostQueryService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<MediaMapper>()
                .AddSingleton<UpsertUserMapper>()
                .AddSingleton<UpsertPostMapper>()
                .AddMediatR(
                        x =>
                        {
                            x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                            x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                        }
                    );
    }
}
