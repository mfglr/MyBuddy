using CommentLikeQueryService.Application.UseCases.UpdateCommentLike;
using Shared.Events.CommentLikeService;

namespace CommentLikeQueryService.Worker.MassTransit.Consumers.UpdateComment_OnCommentDisliked
{
    internal class UpdateComment_OnCommentDisliked_Mapper
    {
        public UpdateCommentLikeRequest Map(CommentDislikedEvent @event) =>
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
