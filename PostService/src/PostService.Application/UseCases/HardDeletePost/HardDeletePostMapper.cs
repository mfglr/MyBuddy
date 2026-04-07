using PostService.Domain;
using Shared.Events;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.HardDeletePost
{
    internal class HardDeletePostMapper
    {
        public PostHardDeletedEvent_Content Map(Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );

        public MediaMessage Map(PostMedia media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Context
            );

        public PostHardDeletedEvent Map(Post post) =>
            new(
                post.Id,
                post.CreatedAt,
                post.UpdatedAt,
                post.SoftDeletedAt,
                true,
                post.Version,
                post.UserId,
                post.Content != null ? Map(post.Content) : null,
                post.Media.Select(Map)
            );
    }
}
