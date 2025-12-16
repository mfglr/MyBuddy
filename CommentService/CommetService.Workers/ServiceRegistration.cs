using CommentService.Application;
using CommentService.Application.UseCases.DeleteComentReplies;
using CommentService.Application.UseCases.DeletePostComments;
using CommentService.Application.UseCases.RestoreCommentReplies;
using CommentService.Application.UseCases.RestorePostComments;
using CommentService.Application.UseCases.SetCommentContentModerationResult;
using CommentService.Domain;
using CommentService.Infrastructure;
using CommetService.Workers;
using CommetService.Workers.Consumers.DeletePostCommentsOnPostDeleted;
using CommetService.Workers.Consumers.DeleteRepliesOnCommentDeleted;
using CommetService.Workers.Consumers.RestorePostCommentsOnPostRestored;
using CommetService.Workers.Consumers.RestoreRepliesOnCommentRestored;
using CommetService.Workers.Consumers.SetCommentContentModerationResult;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CommetService.Workers
{
    internal static class ServiceRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services
                .AddScoped<CommentCreatorDomainService>()
                .AddMediator(cfg =>
                {
                    cfg.AddConsumer<SetCommentContentModerationResultConsumer>();
                    cfg.AddConsumer<DeleteCommentRepliesConsumer>();
                    cfg.AddConsumer<RestoreCommentRepliesConsumer>();
                    cfg.AddConsumer<DeletePostCommentsConsumer>();
                    cfg.AddConsumer<RestorePostCommentsConsumer>();
                });

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddDbContext<MongoContext>(
                    x => x.UseMongoDB(
                        configuration["MongoDbSettings:ConnectionString"]!,
                        configuration["MongoDbSettings:DatabaseName"]!
                    )
                )
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<ICommentRepository, CommentRepository>();

        public static IServiceCollection AddAutoMapper(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddAutoMapper(
                    cfg => {
                        cfg.LicenseKey = configuration["AutoMapper:LicenseKey"]!;
                    },
                    Assembly.GetExecutingAssembly(),
                    Assembly.GetAssembly(typeof(IUnitOfWork))
                );

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration) =>
            services.AddMassTransit(
                x =>
                {
                    x.AddConsumer<SetCommentContentModerationResult_CommentService>();
                    x.AddConsumer<DeleteRepliesOnCommentDeleted>();
                    x.AddConsumer<RestoreRepliesOnCommentRestored>();
                    x.AddConsumer<DeletePostCommentsOnPostDeleted>();
                    x.AddConsumer<RestorePostCommentsOnPostRestored>();

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
