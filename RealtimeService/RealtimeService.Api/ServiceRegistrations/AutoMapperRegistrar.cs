using System.Reflection;

namespace RealtimeService.Api.ServiceRegistrations
{
    public static class AutoMapperRegistrar
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddAutoMapper(
                    x => x.LicenseKey = configuration["LuckPenny:LicenseKey"],
                    Assembly.GetExecutingAssembly()
                );
    }
}
