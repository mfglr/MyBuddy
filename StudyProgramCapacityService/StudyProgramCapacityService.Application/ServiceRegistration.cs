using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyProgramCapacityService.Application.UseCases.GetSPCById;
using StudyProgramCapacityService.Application.UseCases.ReserveSPC;
using System.Reflection;

namespace StudyProgramCapacityService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<ReserveSPCMapper>()
                .AddSingleton<GetSPCByIdMapper>()
                .AddMediatR(
                    x =>
                    {
                        x.LicenseKey = configuration["LuckPenny:LicenseKey"];
                        x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                    }
                );
    }
}
