using MassTransit;
using StudyProgramCapacityService.Worker.MassTransit;
using StudyProgramCapacityService.Worker.MassTransit.Consumers.CreateSPC_OnSPCreated;
using StudyProgramCapacityService.Worker.MassTransit.Consumers.ReserveSPC_OnSPAApprovalValidated;
using StudyProgramCapacityService.Worker.MassTransit.Consumers.ReserveSPC_OnSPACreationValidated;

namespace StudyProgramCapacityService.Worker.MassTransit
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
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetSection(nameof(MassTransitOptions)).Get<MassTransitOptions>()!;
            return services
                .AddSingleton<Consumers.CreateSPC_OnSPCreated.Mapper>()
                .AddSingleton<Consumers.ReserveSPC_OnSPACreationValidated.Mapper>()
                .AddSingleton<Consumers.ReserveSPC_OnSPAApprovalValidated.Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<CreateSPC_OnSPCreated>();
                        brc.AddConsumer<ReserveSPC_OnSPACreationValidated>();
                        brc.AddConsumer<ReserveSPC_OnSPAApprovalValidated>();

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
