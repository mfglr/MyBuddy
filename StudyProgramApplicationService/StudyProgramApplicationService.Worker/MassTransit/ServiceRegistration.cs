using MassTransit;
using StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsApproved_OnSPCReserved;
using StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsAwaitingCapacityReservation_OnSPAApprovalValidated;
using StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsRejected_OnSPAAprovalInvalidated;
using StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsRejected_OnSPACreationInvalidated;
using StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsRejected_OnSPCExceeded;
using StudyProgramApplicationService.Worker.MassTransit.Consumers.UpdateSPAStatus_OnSPACreationValidated;

namespace StudyProgramApplicationService.Worker.MassTransit
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
                .AddSingleton<Consumers.UpdateSPAStatus_OnSPACreationValidated.Mapper>()
                .AddSingleton<Consumers.MarkSPAAsRejected_OnSPACreationInvalidated.Mapper>()
                .AddSingleton<Consumers.MarkSPAAsApproved_OnSPCReserved.Mapper>()
                .AddSingleton<Consumers.MarkSPAAsRejected_OnSPCExceeded.Mapper>()
                .AddSingleton<Consumers.MarkSPAAsAwaitingCapacityReservation_OnSPAApprovalValidated.Mapper>()
                .AddSingleton<Consumers.MarkSPAAsRejected_OnSPAAprovalInvalidated.Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<UpdateSPAStatus_OnSPACreationValidated>();
                        brc.AddConsumer<MarkSPAAsRejected_OnSPACreationInvalidated>();

                        brc.AddConsumer<MarkSPAAsApproved_OnSPCReserved>();
                        brc.AddConsumer<MarkSPAAsRejected_OnSPCExceeded>();

                        brc.AddConsumer<MarkSPAAsAwaitingCapacityReservation_OnSPAApprovalValidated>();
                        brc.AddConsumer<MarkSPAAsRejected_OnSPAAprovalInvalidated>();


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
