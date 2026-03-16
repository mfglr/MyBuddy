using CommentService.Application.UseCases.SetCommentContentModerationResult;
using MassTransit;
using MediatR;
using Shared.Events.Comment;

namespace CommetService.Workers.MassTransit.Consumers
{
    internal class SetModerationResult_OnCommentContentClassified_CommentService(ISender sender) : IConsumer<CommentContentClassifiedEvent>
    {
        public Task Consume(ConsumeContext<CommentContentClassifiedEvent> context) =>
            sender
                .Send(
                    new SetCommentContentModerationResultRequest(context.Message.Id,context.Message.ModerationResult),
                    context.CancellationToken
                );
    }
}
