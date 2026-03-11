using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.RestorePost
{
    internal class RestorePostMapper
    {
        private PostRestoredEvent_Content Map(Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );
        private PostRestoredEvent_Media Map(Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Metadata,
                media.ModerationResult,
                media.Thumbnails,
                media.Transcodings,
                media.Instruction
            );
        public PostRestoredEvent Map(Post post) =>
            new(
                post.Id,
                post.CreatedAt,
                post.UpdatedAt,
                post.DeletedAt,
                post.IsDeleted,
                post.Version,
                post.IsValidVersion,
                post.UserId,
                post.Content != null ? Map(post.Content) : null,
                post.Media.Select(Map)
            );
    }
}
