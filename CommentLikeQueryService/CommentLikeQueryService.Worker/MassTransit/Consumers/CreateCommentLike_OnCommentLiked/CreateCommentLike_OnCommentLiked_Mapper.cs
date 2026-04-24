using CommentLikeQueryService.Application.UseCases.CreateCommentLike;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.CreateCommentLike_OnCommentLiked
{
    internal class CreateCommentLike_OnCommentLiked_Mapper
    {
        public CreateCommentLikeRequest Map(CommentLikedEvent @event) =>
            new(
                @event.CommentId,
                @event.SequenceId,
                @event.UserId,
                @event.CreatedAt
            );

    }
}
