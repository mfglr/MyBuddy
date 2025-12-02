using MassTransit;
using Microsoft.EntityFrameworkCore;
using QueryService.Workers;
using QueryService.Workers.PostDomain;
using System.Reflection;

namespace QueryService.Workers
{
    internal static class ServiceRegistration
    {

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddAutoMapper(
                    cfg => {
                        cfg.LicenseKey = configuration["AutoMapper:LicenseKey"]!;
                    },
                    Assembly.GetExecutingAssembly()
                );

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configration) =>
            services.AddMassTransit(
                x =>
                {
                    x.AddConsumer<CreatePost>();

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(configration["RabbitMQ:Host"], configration["RabbitMQ:VirtualHost"], h =>
                        {
                            h.Username(configration["RabbitMQ:UserName"]!);
                            h.Password(configration["RabbitMQ:Password"]!);
                        });

                        var retryLimit = 1;

                        cfg.ReceiveEndpoint("CreatePost", e =>
                        {
                            e.UseMessageRetry(rc =>
                            {
                                rc.Immediate(retryLimit);
                                rc.Handle<DbUpdateConcurrencyException>();
                            });
                            e.ConfigureConsumer<CreatePost>(context);
                        });
                    });

                }
            );
    }
}
