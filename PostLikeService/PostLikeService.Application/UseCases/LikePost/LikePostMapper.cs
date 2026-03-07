using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.LikePost
{
    internal class LikePostMapper
    {
        public PostLikedEvent Map(PostLike like) =>
            new(
                like.Id.UserId,
                like.Id.PostId,
                like.CreatedAt,
                like.Version,
                like.IsDeleted,
                like.DeletedAt
            );
    }
}
