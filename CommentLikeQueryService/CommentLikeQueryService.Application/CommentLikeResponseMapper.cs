using CommentLikeQueryService.Domain.CommentLikeAggregate;

namespace CommentLikeQueryService.Application
{
    internal class CommentLikeResponseMapper
    {
        public CommentLikeResponse Map(CommentLike projection) =>
            new(
                projection.Id.CommentId,
                projection.Id.SequenceId,
                projection.CreatedAt,
                projection.Id.UserId,
                projection.User.UserName,
                projection.User.Name,
                projection.User.Media
            );

        public List<CommentLikeResponse> Map(List<CommentLike> projections) =>
            [.. projections.Select(Map)];
    }
}
