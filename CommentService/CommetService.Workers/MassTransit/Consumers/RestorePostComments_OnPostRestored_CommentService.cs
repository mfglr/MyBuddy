using CommentService.Application.UseCases.RestorePostComments;
using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace CommetService.Workers.MassTransit.Consumers
{
    internal class RestorePostComments_OnPostRestored_CommentService(ISender sender) : IConsumer<PostRestoredEvent>
    {
        public Task Consume(ConsumeContext<PostRestoredEvent> context) =>
            sender
                .Send(
                    new RestorePostCommentsRequest(context.Message.Id),
                    context.CancellationToken
                );
    }
}
