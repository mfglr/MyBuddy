using CommentLikeQueryService.Domain;

namespace CommentLikeQueryService.Application
{
    internal class CommentLikeResponseMapper
    {
        public CommentLikeResponse Map(CommentLikeProjection projection) =>
            new(
                projection.Id.CommentId,
                projection.Id.SequenceId,
                projection.CommentLike.CreatedAt,
                projection.User.Id,
                projection.User.UserName,
                projection.User.Name,
                projection.User.Media
            );

        public List<CommentLikeResponse> Map(List<CommentLikeProjection> projections) =>
            [.. projections.Select(Map)];
    }
}
