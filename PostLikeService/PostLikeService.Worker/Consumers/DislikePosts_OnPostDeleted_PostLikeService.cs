using MassTransit;
using MediatR;
using PostLikeService.Application.UseCases.DislikePosts;
using Shared.Events.PostService;

namespace PostLikeService.Worker.Consumers
{
    internal class DislikePosts_OnPostDeleted_PostLikeService(ISender sender) : IConsumer<PostDeletedEvent>
    {
        public Task Consume(ConsumeContext<PostDeletedEvent> context) =>
            sender.Send(new DislikesPostsRequest(context.Message.Id), context.CancellationToken);
    }
}
