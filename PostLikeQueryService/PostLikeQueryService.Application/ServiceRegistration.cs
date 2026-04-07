using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostLikeQueryService.Application.UseCases.UpsertUser;
using System.Reflection;

namespace PostLikeQueryService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<UpsertUserMapper>()
                .AddMediatR(
                        x =>
                        {
                            x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                            x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                        }
                    );
    }
}
