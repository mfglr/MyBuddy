using PostLikeService.Domain;
using Shared.Events.PostLikeService;

namespace PostLikeService.Application.UseCases.DislikePosts
{
    internal class DislikePostsMapper
    {
        public PostDislikedEvent Map(PostLike like) =>
            new(
                like.Id.UserId,
                like.Id.PostId,
                like.SequenceId,
                like.CreatedAt,
                like.Version,
                like.IsDeleted,
                like.DeletedAt
            );
    }
}
