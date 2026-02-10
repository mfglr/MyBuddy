using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.MarkMessagesAsDelivered
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_MarkMessagasAsReceived_UseCase(this IServiceCollection services) =>
            services
                .AddAutoMapper(x => x.AddProfile<MarkMessagesAsDeliveredMapper>())
                .AddTransient<IRequestHandler<MarkMessagesAsDeliveredRequest>, MarkMessagesAsDeliveredHandler>();
    }
}
