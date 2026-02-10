using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.Disconnect
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_Disconnect_UseCase(this IServiceCollection services) =>
            services
                .AddTransient<IRequestHandler<DisconnectRequest>, DisconnectHandler>();
    }
}
