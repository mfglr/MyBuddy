using CommentLikeQueryService.Application.UseCases.UpdateCommentLike;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateComment_OnCommentLiked
{
    internal class UpdateComment_OnCommentLiked_Mapper
    {
        public UpdateCommentLikeRequest Map(CommentLikedEvent @event) =>
            new(
                new(
                    @event.CommentId,
                    @event.SequenceId
                ),
                new(
                    @event.CreatedAt,
                    @event.DeletedAt,
                    @event.IsDeleted,
                    @event.Version
                )
            );
    }
}
