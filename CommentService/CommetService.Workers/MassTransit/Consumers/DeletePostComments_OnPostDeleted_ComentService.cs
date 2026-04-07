using CommentService.Application.UseCases.DeletePostComments;
using MassTransit;
using MediatR;
using Shared.Events.PostService;

namespace CommetService.Workers.MassTransit.Consumers
{
    internal class DeletePostComments_OnPostDeleted_ComentService(ISender sender) : IConsumer<PostSoftDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostSoftDeletedEvent> context) =>
            sender.Send(new DeletePostCommentsRequest(context.Message.Id), context.CancellationToken);
    }
}
