using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.Connect
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_Connect_UseCase(this IServiceCollection services) =>
            services
                .AddScoped<IRequestHandler<ConnectRequest>, ConnectHandler>();
    }
}
