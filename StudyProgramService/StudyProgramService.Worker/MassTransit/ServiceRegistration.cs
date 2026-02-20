using MassTransit;
using StudyProgramService.Worker.MassTransit.Consumers.ValidateSPAAproval_OnSPAApprovalRequested;
using StudyProgramService.Worker.MassTransit.Consumers.ValidateSPACreation_OnSPACreated;

namespace StudyProgramService.Worker.MassTransit
{
    internal class MassTransitOptions
    {
        public required string Host { get; set; }
        public required string VirtualHost { get; set; }
        public required string Password { get; set; }
        public required string UserName { get; set; }
    }

    internal static class ServiceRegistration
    {
        public static IServiceCollection AddConsumers(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<Consumers.ValidateSPACreation_OnSPACreated.Mapper>()
                .AddSingleton<Consumers.ValidateSPAAproval_OnSPAApprovalRequested.Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<ValidateSPACreation_OnSPACreated>();
                        brc.AddConsumer<ValidateSPAAproval_OnSPAApprovalRequested>();

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
