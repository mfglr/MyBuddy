using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramInviteService.Application.UseCases.CreateSPI;
using System.Reflection;

namespace StudyProgramInviteService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<CreateSPIMapper>()
                .AddMediatR(
                    x =>
                    {
                        x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                        x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    }
                );
    }
}
