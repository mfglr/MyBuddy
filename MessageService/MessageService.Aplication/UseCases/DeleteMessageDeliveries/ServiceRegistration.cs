using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.DeleteMessageDeliveries
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_DeleteMessageDeliveries_UseCase(this IServiceCollection services,IConfiguration configuration) =>
            services
                .AddMediatR(cfg => cfg.LicenseKey = configuration["LuckPenny:LicenseKey"])
                .AddTransient<IRequestHandler<DeleteMessageDeliveriesRequest>, DeleteMessageDeliveriesHandler>();
    }
}
