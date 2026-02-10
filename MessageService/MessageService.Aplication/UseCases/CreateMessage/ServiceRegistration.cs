using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.CreateMessage
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_CreateMessage_UseCase(this IServiceCollection services) =>
            services
                .AddAutoMapper(x => x.AddProfile<CreateMessageMapper>())
                .AddTransient<IRequestHandler<CreateMessageRequest, CreateMessageResponse>, CreateMessageHandler>();
    }
}
