using MassTransit;
using PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostDisliked;
using PostLikeQueryService.Worker.Consumers.UpgradePostLike_OnPostLiked;
using PostLikeQueryService.Worker.Consumers.UpgradeUser;
using PostLikeQueryService.Worker.ServiceRegistrations;

namespace PostLikeQueryService.Worker.ServiceRegistrations
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
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<UpgradeUser_OnUserCreated_PostLikeQueryService>();
                        brc.AddConsumer<UpgradePostLike_OnPostLiked_PostLikeQueryService>();
                        brc.AddConsumer<UpgradePostLiked_OnPostDisliked_PostLikeQueryService>();

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
    }
}
