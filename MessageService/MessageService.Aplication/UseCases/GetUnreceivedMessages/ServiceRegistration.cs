using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Aplication.UseCases.GetUnreceivedMessages
{
    public static class ServiceRegistration
    {
        public static IServiceCollection Add_GetUnreceivedMessages_UseCase(this IServiceCollection services) =>
            services
                .AddTransient<IRequestHandler<GetUnreceivedMessagesRequest, GetUnreceivedMessagesResponse>,GetUnreceivedMessagesHandler>()
                .AddAutoMapper(cfg => cfg.AddProfile<GetUnreceivedMessagesMapper>());
    }
}
