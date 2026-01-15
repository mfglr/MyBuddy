using CommentService.Application.UseCases.RestoreCommentReplies;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommetService.Workers.Consumers
{
    internal class RestoreRepliesConsumer_CommentService(ISender sender) : IConsumer<CommentRestoredEvent>
    {
        private readonly ISender _sender = sender;

        public Task Consume(ConsumeContext<CommentRestoredEvent> context) =>
            _sender
                .Send(
                    new RestoreCommentRepliesRequest(context.Message.Id),
                    context.CancellationToken
                );
    }
}
