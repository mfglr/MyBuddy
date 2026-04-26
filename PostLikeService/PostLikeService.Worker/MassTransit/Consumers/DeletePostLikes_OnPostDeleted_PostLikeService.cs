using MassTransit;
using MediatR;
using PostLikeService.Application.UseCases.DeletePostLikes;
using Shared.Events.PostService;

namespace PostLikeService.Worker.MassTransit.Consumers
{
    internal class DeletePostLikes_OnPostDeleted_PostLikeService(ISender sender) : IConsumer<PostDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostDeletedEvent> context) =>
            sender.Send(new DeletePostLikesRequest(context.Message.Id), context.CancellationToken);
    }
}
