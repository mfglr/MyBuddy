using CommentQueryService.Domain;

namespace CommentQueryService.Application.UseCases
{
    internal class CommentResponseMapper
    {
        private CommentResponse Map(CommentProjection projection) =>
            new(
                projection.User.Id,
                projection.User.UserName,
                projection.User.Name,
                projection.User.Media,
                projection.Id,
                projection.Comment.CreatedAt,
                projection.Comment.UpdatedAt,
                projection.Comment.PostId,
                projection.Comment.ParentId,
                projection.Comment.RepliedId,
                projection.Comment.Content,
                projection.LikeCount,
                projection.ChildCount
            );

        public IEnumerable<CommentResponse> Map(IEnumerable<CommentProjection> projections) => projections.Select(Map);
    }
}
