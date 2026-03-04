using ContentModerator.Worker.Consumers;
using ContentModerator.Worker.Consumers.CommentDomain;
using ContentModerator.Worker.Consumers.MediaDomain.ClassifyMedia;
using ContentModerator.Worker.Consumers.PostDomain;
using MassTransit;

namespace ContentModerator.Worker.Consumers
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configration) =>
            services
                .AddSingleton<Consumers.MediaDomain.ClassifyMedia.Mapper>()
                .AddMassTransit(
                    x =>
                    {
                        x.AddConsumer<ClassifyMedia>();

                        x.AddConsumer<ClassifyPostContent_OnPostCreated_ContentModerator>();
                        x.AddConsumer<ClassifyPostContent_OnPostContentUpdated_ContentModerator>();

                        x.AddConsumer<ClassifyCommentContent_OnCommentCreated_ContentModerator>();
                        x.AddConsumer<ClassifyCommentContent_OnContentUpdated_ContentModerator>();

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
