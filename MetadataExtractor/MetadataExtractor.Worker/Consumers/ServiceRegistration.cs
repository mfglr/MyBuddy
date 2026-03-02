using MassTransit;
using MetadataExtractor.Worker.Consumers;
using MetadataExtractor.Worker.Consumers.ExtractMetadata;

namespace MetadataExtractor.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configration) =>
            services
                .AddSingleton<Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        //x.AddEntityFrameworkOutbox<SqlContext>(o =>
                        //{
                        //    o.UsePostgres();
                        //    o.UseBusOutbox();
                        //});

                        x.AddConsumer<ExtractMetadata_OnMediaCreated>();
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(configration["RabbitMQ:Host"], configration["RabbitMQ:VirtualHost"], h =>
                            {
                                h.Username(configration["RabbitMQ:UserName"]!);
                                h.Password(configration["RabbitMQ:Password"]!);
                            });

                            cfg.ConfigureEndpoints(context);
                        });
                    }
                );
    }
}
