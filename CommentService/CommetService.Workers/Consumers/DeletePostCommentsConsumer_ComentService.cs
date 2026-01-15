using CommentService.Application.UseCases.DeletePostComments;
using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace CommetService.Workers.Consumers
{
    internal class DeletePostCommentsConsumer_ComentService(ISender sender) : IConsumer<PostDeletedEvent>
    {
        private readonly ISender _sender = sender;

        public Task Consume(ConsumeContext<PostDeletedEvent> context) =>
            _sender.Send(new DeletePostCommentsRequest(context.Message.Id), context.CancellationToken);
    }
}
