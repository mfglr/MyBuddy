using MassTransit;
using PostService.Application;
using PostService.Application.UseCases.SetPostContentModerationResult;
using PostService.Application.UseCases.SetPostMedia;
using PostService.Domain;
using PostService.Infrastructure;
using PostService.Workers;
using PostService.Workers.Consumers.SetPostContentModerationResult;
using PostService.Workers.Consumers.SetPostMedia;
using System.Reflection;

namespace PostService.Workers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<SetPostMediaConsumer>();
                    cfg.AddConsumer<SetPostContentModerationResultConsumer>();
                });

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddScoped<IBlobService, LocalBlobService>()
                .AddScoped<MongoContext>()
                .AddScoped<IPostRepository, PostRepository>();

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddAutoMapper(
                    cfg => {
                        cfg.LicenseKey = configuration["AutoMapper:LicenseKey"]!;
                    },
                    Assembly.GetAssembly(typeof(Application.IBlobService)),
                    Assembly.GetExecutingAssembly()
                );

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configration) =>
            services.AddMassTransit(
                x =>
                {
                    x.AddConsumer<SetPostContentModerationResult_PostService>();
                    x.AddConsumer<SetPostMedia_PostService>();

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(configration["RabbitMQ:Host"], configration["RabbitMQ:VirtualHost"], h =>
                        {
                            h.Username(configration["RabbitMQ:UserName"]!);
                            h.Password(configration["RabbitMQ:Password"]!);
                        });

                        var retryLimit = 5;

                        cfg.ReceiveEndpoint("SetPostContentModerationResult_PostService", e =>
                        {
                            e.UseMessageRetry(rc =>
                            {
                                rc.Immediate(retryLimit);
                                rc.Handle<AppConcurrencyException>();
                            });
                            e.ConfigureConsumer<SetPostContentModerationResult_PostService>(context);
                        });

                        cfg.ReceiveEndpoint("SetPostMedia_PostService", e =>
                        {
                            e.UseMessageRetry(rc =>
                            {
                                rc.Immediate(retryLimit);
                                rc.Handle<AppConcurrencyException>();
                            });
                            e.ConfigureConsumer<SetPostMedia_PostService>(context);
                        });
                    });

                }
            );
    }
}
