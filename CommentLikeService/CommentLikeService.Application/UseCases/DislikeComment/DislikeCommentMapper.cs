using CommentLikeService.Domain;
using Shared.Events.CommentLikeService;

namespace CommentLikeService.Application.UseCases.DislikeComment
{
    internal class DislikeCommentMapper
    {
        public CommentDislikedEvent Map(CommentLike commentLike) =>
            new(
                commentLike.Id.CommentId,
                commentLike.Id.UserId,
                commentLike.SequenceId,
                commentLike.CreatedAt
            );
    }
}
