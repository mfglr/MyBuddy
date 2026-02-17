using MassTransit;
using StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkAsRejected_OnValidationFailedStudyProgram;
using StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkAsValidated_OnValidationSuccessByStudyProgram;

namespace EnrollmentRequestService.Worker.MassTransit
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
                .AddSingleton<MarkAsRejected_OnStudyProgramValidationFailed_Mapper>()
                .AddSingleton<MarkAsValidated_OnValidationSuccessByStudyProgram_Mapper>()
                .AddMassTransit(
                    brc =>
                    {
                        brc.AddConsumer<MarkAsRejected_OnStudyProgramValidationFailed_EnrrollmentRequestService>();
                        brc.AddConsumer<MarkAsValidated_OnValidationSuccessByStudyProgram_StudyProgramApplicationService>();
                        
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
