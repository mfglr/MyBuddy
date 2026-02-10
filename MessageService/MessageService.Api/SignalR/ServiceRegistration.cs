using MessageService.Aplication.UseCases.SendMessage;

namespace MessageService.Api.SignalR
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddCustomSignalR(this IServiceCollection services)
        {
            services.AddSignalR();
            services.AddScoped<IMessageRouter, MessageRouter>();
            return services;
        }
    }
}
