using CommentLikeService.Domain;
using Shared.Events;
using Shared.Events.CommentLikeService;

namespace CommentLikeService.Application.UseCases.LikeComment
{
    internal class LikeCommentMapper
    {
        public CommentLikeCreatedEvent MapCreatedEvent(CommentLike commentLike, CurrentUser currentUser) =>
            new(
                commentLike.Id.CommentId,
                commentLike.Id.UserId,
                commentLike.SequenceId,
                commentLike.CreatedAt,
                commentLike.DeletedAt,
                commentLike.IsDeleted,
                commentLike.Version,
                currentUser
            );

        public CommentLikedEvent MapLikedEvent(CommentLike commentLike) =>
            new(
                commentLike.Id.CommentId,
                commentLike.Id.UserId,
                commentLike.SequenceId,
                commentLike.CreatedAt,
                commentLike.DeletedAt,
                commentLike.IsDeleted,
                commentLike.Version
            );
    }
}
