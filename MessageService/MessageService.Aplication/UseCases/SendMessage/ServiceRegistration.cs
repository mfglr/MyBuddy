using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.SendMessage
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_SendMessage_UseCase(this IServiceCollection services) =>
            services
                .AddTransient<IRequestHandler<SendMessageRequest>, SendMessageHandler>();
    }
}
