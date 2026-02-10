using MessageService.Aplication.UseCases.Connect;
using MessageService.Aplication.UseCases.CreateMessage;
using MessageService.Aplication.UseCases.DeleteContent;
using MessageService.Aplication.UseCases.Disconnect;
using MessageService.Aplication.UseCases.GetConnectionStatus;
using MessageService.Aplication.UseCases.GetUnreceivedMessages;
using MessageService.Aplication.UseCases.MarkMessagesAsDelivered;
using MessageService.Aplication.UseCases.MarkMessagesAsSeen;
using MessageService.Aplication.UseCases.SendMessage;
using MessageService.Aplication.UseCases.UpdateContent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MessageService.Aplication
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .Add_Connect_UseCase()
                .Add_CreateMessage_UseCase()
                .Add_Disconnect_UseCase()
                .Add_GetConnectionStatus_UseCase()
                .Add_GetUnreceivedMessages_UseCase()
                .Add_MarkMessagasAsReceived_UseCase()
                .Add_MarkMessagesAsSeen_UseCase()
                .Add_SendMessage_UseCase()
                .AddAutoMapper(cfg => cfg.LicenseKey = configuration["LuckPenny:LicenseKey"])
                .AddMediatR(cfg => cfg.LicenseKey = configuration["LuckPenny:LicenseKey"]);
    }
}
