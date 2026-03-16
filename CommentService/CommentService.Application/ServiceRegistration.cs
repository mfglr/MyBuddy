using CommentService.Application.UseCases.CreateComment;
using CommentService.Application.UseCases.DeleteComentReplies;
using CommentService.Application.UseCases.DeleteComment;
using CommentService.Application.UseCases.DeletePostComments;
using CommentService.Application.UseCases.RestoreComment;
using CommentService.Application.UseCases.RestoreCommentReplies;
using CommentService.Application.UseCases.RestorePostComments;
using CommentService.Application.UseCases.SetCommentContentModerationResult;
using CommentService.Application.UseCases.UpdateCommentContent;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CommentService.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) =>
            services
                .AddSingleton<CreateCommentMapper>()
                .AddSingleton<DeleteCommentRepliesMapper>()
                .AddSingleton<DeleteCommentMapper>()
                .AddSingleton<DeletePostCommentsMapper>()
                .AddSingleton<RestoreCommentMapper>()
                .AddSingleton<RestoreCommentRepliesMapper>()
                .AddSingleton<RestorePostCommentsMapper>()
                .AddSingleton<SetCommentContentModerationResultMapper>()
                .AddSingleton<UpdateCommentContentMapper>()
                .AddMediatR(cfg =>
                {
                    cfg.LicenseKey = configuration["LuckPenny:LicenseKey"];
                    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                })
                .AddTransient(typeof(IPipelineBehavior<,>),typeof(UnitOfWorkPipelineBehavior<,>));
    }
}
