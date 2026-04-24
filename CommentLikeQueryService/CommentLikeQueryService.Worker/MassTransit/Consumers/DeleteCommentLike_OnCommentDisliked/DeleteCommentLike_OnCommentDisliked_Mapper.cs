using CommentLikeQueryService.Application.UseCases.DeleteCommentLike;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.DeleteCommentLike_OnCommentDisliked
{
    internal class DeleteCommentLike_OnCommentDisliked_Mapper
    {
        public DeleteCommentLikeRequest Map(CommentDislikedEvent @event) =>
            new(
                @event.CommentId,
                @event.SequenceId,
                @event.UserId
            );
    }
}
