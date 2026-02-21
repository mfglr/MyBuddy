using MassTransit;
using StudyProgramInviteService.Worker.MassTransit;
using StudyProgramInviteService.Worker.MassTransit.Consumers.InvalidateSPICreation_OnSPICreationInvalidated;
using StudyProgramInviteService.Worker.MassTransit.Consumers.ValidateSPICreation_OnSPICreationValidated;

namespace StudyProgramInviteService.Worker.MassTransit
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<Consumers.InvalidateSPICreation_OnSPICreationInvalidated.Mapper>()
                .AddSingleton<Consumers.ValidateSPICreation_OnSPICreationValidated.Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<InvalidateSPICreation_OnSPICreationInvalidated>();
                        brc.AddConsumer<ValidateSPICreation_OnSPICreationValidated>();

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
