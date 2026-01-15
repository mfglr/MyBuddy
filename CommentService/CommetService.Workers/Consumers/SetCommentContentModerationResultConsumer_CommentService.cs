using CommentService.Application.UseCases.SetCommentContentModerationResult;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommetService.Workers.Consumers
{
    internal class SetCommentContentModerationResultConsumer_CommentService(ISender sender) : IConsumer<CommentContentClassifiedEvent>
    {
        private readonly ISender _sender = sender;
        public Task Consume(ConsumeContext<CommentContentClassifiedEvent> context) =>
            _sender
                .Send(
                    new SetCommentContentModerationResultRequest(context.Message.Id,context.Message.ModerationResult),
                    context.CancellationToken
                );
    }
}
