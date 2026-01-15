using CommentService.Application.UseCases.RestorePostComments;
using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace CommetService.Workers.Consumers
{
    internal class RestorePostCommentsConsumer_CommentService(ISender sender) : IConsumer<PostRestoredEvent>
    {
        private readonly ISender _sender = sender;

        public Task Consume(ConsumeContext<PostRestoredEvent> context) =>
            _sender
                .Send(
                    new RestorePostCommentsRequest(context.Message.Id),
                    context.CancellationToken
                );
    }
}
