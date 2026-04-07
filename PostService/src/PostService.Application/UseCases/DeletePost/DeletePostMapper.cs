using PostService.Domain;
using Shared.Events;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.DeletePost
{
    internal class DeletePostMapper
    {
        private PostDeletedEvent_Content Map(Content content) =>
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

        public PostDeletedEvent Map(Post post) =>
            new(
                post.Id,
                post.CreatedAt,
                post.UpdatedAt,
                post.DeletedAt,
                post.IsDeleted,
                post.Version,
                post.UserId,
                post.Content != null ? Map(post.Content) : null,
                post.Media.Select(Map)
            );
    }
}
