using CommentQueryService.Domain;
using CommentQueryService.Domain.CommentAggregate;

namespace CommentQueryService.Application.UseCases
{
    internal class CommentResponseMapper
    {
        private CommentResponse_Media Map(CommentMedia media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                media.Transcodings
            );

        public CommentResponse Map(Comment comment) =>
            new(
                comment.UserId,
                comment.User.UserName,
                comment.User.Name,
                comment.User.Media != null ? Map(comment.User.Media) : null,
                comment.Id,
                comment.CreatedAt,
                comment.UpdatedAt,
                comment.PostId,
                comment.ParentId,
                comment.RepliedId,
                comment.Content,
                comment.LikeCount,
                comment.ChildCount
            );
    }
}
