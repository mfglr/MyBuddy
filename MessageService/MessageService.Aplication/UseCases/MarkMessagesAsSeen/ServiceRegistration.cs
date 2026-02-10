using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.MarkMessagesAsSeen
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_MarkMessagesAsSeen_UseCase(this IServiceCollection services) =>
            services
                .AddTransient<IRequestHandler<MarkMessagesAsSeenRequest>, MarkMessagesAsSeenHandler>()
                .AddAutoMapper(x => x.AddProfile<MarkMessagesAsSeenMapper>());
    }
}
