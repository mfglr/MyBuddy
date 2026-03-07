using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.LikePosts
{
    internal class LikePostsMapper
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
