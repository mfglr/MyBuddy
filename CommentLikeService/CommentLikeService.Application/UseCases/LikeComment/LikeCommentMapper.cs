using CommentLikeService.Domain;
using Shared.Events.CommentLikeService;

namespace CommentLikeService.Application.UseCases.LikeComment
{
    internal class LikeCommentMapper
    {
        public CommentLikedEvent Map(CommentLike commentLike) =>
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
