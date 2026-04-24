using CommentLikeQueryService.Domain.CommentLikeAggregate;
using CommentLikeQueryService.Domain.UserAggregate;

namespace CommentLikeQueryService.Application.UseCases.CreateCommentLike
{
    internal class CreateCommentLikeMapper
    {
        private CommentLikeUser Map(User user) =>
            new(
                user.Version,
                user.Name,
                user.UserName,
                user.Media
            );

        public CommentLike Map(CreateCommentLikeRequest request, User user) =>
            new(
                new(
                    request.CommentId,
                    request.SequenceId,
                    request.UserId
                ),
                request.CreatedAt,
                Map(user)
            );
    }
}
