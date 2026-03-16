using CommentService.Application.UseCases.RestoreCommentReplies;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommetService.Workers.MassTransit.Consumers
{
    internal class RestoreReplies_OnCommentRestored_CommentService(ISender sender) : IConsumer<CommentRestoredEvent>
    {
        public Task Consume(ConsumeContext<CommentRestoredEvent> context) =>
            sender
                .Send(
                    new RestoreCommentRepliesRequest(context.Message.Id),
                    context.CancellationToken
                );
    }
}
