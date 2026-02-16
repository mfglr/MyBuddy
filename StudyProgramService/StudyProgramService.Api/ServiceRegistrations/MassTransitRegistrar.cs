using MassTransit;
using MassTransit.Configuration;
using StudyProgramService.Api.ServiceRegistrations;
using StudyProgramService.Infrastructure.PostgreSqlDb;

namespace StudyProgramService.Api.ServiceRegistrations
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
                        brc.AddEntityFrameworkOutbox<PostgreSqlContext>(o =>
                        {
                            o.UsePostgres();
                            o.UseBusOutbox();
                        });

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
