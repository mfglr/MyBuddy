using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.SetPostContentModerationResult
{
    internal class SetPostContentModerationResultMapper
    {
        private PostContentModerationResultSetEvent_Content Map(Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );
        private PostContentModerationResultSetEvent_Media Map(Media media) =>
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
        public PostContentModerationResultSetEvent Map(Post post) =>
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
