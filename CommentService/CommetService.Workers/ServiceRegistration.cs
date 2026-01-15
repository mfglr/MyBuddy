using CommetService.Workers;
using CommetService.Workers.Consumers;
using MassTransit;

namespace CommetService.Workers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration) =>
            services.AddMassTransit(
                x =>
                {
                    x.AddConsumer<SetCommentContentModerationResultConsumer_CommentService>();
                    x.AddConsumer<DeleteRepliesConsumer_CommentService>();
                    x.AddConsumer<RestoreRepliesConsumer_CommentService>();
                    x.AddConsumer<DeletePostCommentsConsumer_ComentService>();
                    x.AddConsumer<RestorePostCommentsConsumer_CommentService>();

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(configuration["RabbitMQ:Host"], configuration["RabbitMQ:VirtualHost"], h =>
                        {
                            h.Username(configuration["RabbitMQ:UserName"]!);
                            h.Password(configuration["RabbitMQ:Password"]!);
                        });
                        cfg.ConfigureEndpoints(context);
                    });
                }
            );
    }
}
