using Microsoft.Extensions.DependencyInjection;

namespace UserService.Application.UseCases.CreateMedia
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection Add_CreateMedia_UseCase(this IServiceCollection services) =>
            services
                .AddSingleton<MediaTypeValidator>();
    }
}
