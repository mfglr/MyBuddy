using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.DeleteMessages
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_DeletMessages_UseCase(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMediatR(cfg => cfg.LicenseKey = configuration["LuckPenny:LicenseKey"])
                .AddTransient<IRequestHandler<DeleteMessagesRequest>, DeleteMessagesHandler>();
    }
}
