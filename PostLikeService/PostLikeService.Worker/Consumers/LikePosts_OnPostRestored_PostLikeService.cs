using MassTransit;
using MediatR;
using PostLikeService.Application.UseCases.LikePosts;
using Shared.Events.PostService;

namespace PostLikeService.Worker.Consumers
{
    internal class LikePosts_OnPostRestored_PostLikeService(ISender sender) : IConsumer<PostRestoredEvent>
    {
        public Task Consume(ConsumeContext<PostRestoredEvent> context) =>
            sender.Send(new LikesPostsRequest(context.Message.Id), context.CancellationToken);
    }
}
