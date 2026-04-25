using MassTransit;
using MediatR;
using PostLikeService.Application.UseCases.DeletePostLikes;
using Shared.Events.PostService;

namespace PostLikeService.Worker.MassTransit.Consumers
{
    internal class DeletePostLikes_OnPostDeleted_PostLikeService(ISender sender) : IConsumer<PostSoftDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostSoftDeletedEvent> context) =>
            sender.Send(new DeletePostLikesRequest(context.Message.Id), context.CancellationToken);
    }
}
