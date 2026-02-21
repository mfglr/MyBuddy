using MassTransit;
using StudyProgramInviteService.Api.MassTransit;

namespace StudyProgramInviteService.Api.MassTransit
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddMassTransit(
                    brc =>
                    {
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
                        });
                    }
                );
        }
    }
}
