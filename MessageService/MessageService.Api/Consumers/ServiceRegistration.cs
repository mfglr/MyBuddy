using MassTransit;
using MessageService.Api.Consumers;
using MessageService.Api.Consumers.SendMessage_OnMessageCreated;
using MessageService.Api.Consumers.SendMessage_OnMessagesMarkedAsReceived;
using MessageService.Api.Consumers.SendMessage_OnMessagesMarkedAsSeen;

namespace MessageService.Api.Consumers
{
    internal class MassTransitOptions
    {
        public required string Host { get; set; }
        public required string VirtualHost { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }
    }

    internal static class MassTransitRegistrar
    {
        private static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<SendMessage_OnMessageCreated_MessageService>();
                        brc.AddConsumer<SendMessage_OnMessagesMarkedAsReceived_MessageService>();
                        brc.AddConsumer<SendMessage_OnMessageMarkedAsSeen_MessageService>();

                        brc.UsingRabbitMq((context, rbgc) =>
                        {
                            rbgc.Host(
                                option.Host,
                                option.VirtualHost,
                                rhc =>
                                {
                                    rhc.Username(option.UserName);
                                    rhc.Password(option.Password);
                                }
                            );
                            rbgc.ConfigureEndpoints(context);
                        });
                    }
                );
        }

        private static IServiceCollection AddMappers(this IServiceCollection services) =>
            services
                .AddSingleton<SendMessage_OnMessageCreated.Mapper>()
                .AddSingleton<SendMessage_OnMessagesMarkedAsReceived.Mapper>()
                .AddSingleton<SendMessage_OnMessagesMarkedAsSeen.Mapper>();

        public static IServiceCollection AddConsumers(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddMassTransit(configuration)
                .AddMappers();
    }
}
