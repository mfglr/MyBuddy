using MassTransit;
using MediatR;
using PostLikeService.Application.UseCases.DislikePosts;
using Shared.Events.PostService;

namespace PostLikeService.Worker.MassTransit.Consumers
{
    internal class DislikePosts_OnPostDeleted_PostLikeService(ISender sender) : IConsumer<PostSoftDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostSoftDeletedEvent> context) =>
            sender.Send(new DislikesPostsRequest(context.Message.Id), context.CancellationToken);
    }
}
