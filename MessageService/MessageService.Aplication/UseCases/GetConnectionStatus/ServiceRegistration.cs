using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.GetConnectionStatus
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_GetConnectionStatus_UseCase(this IServiceCollection services) =>
            services
                .AddTransient<IRequestHandler<GetConnectionStatusByIdRequest,GetConnectionStatusByIdResponse>, GetConnectionByStatusHandler>();
    }
}
