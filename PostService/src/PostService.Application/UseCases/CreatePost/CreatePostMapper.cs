using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.CreatePost
{
    internal class CreatePostMapper
    {
        private PostCreatedEvent_Media Map(Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Instruction
            );

        public PostCreatedEvent Map(Post post) =>
            new(
                post.Id,
                post.CreatedAt,
                post.UpdatedAt,
                post.UserId,
                post.Version,
                post.IsDeleted,
                post.Content != null ? new PostCreatedEvent_Content(post.Content.Value) : null,
                post.Media.Select(Map),
                post.IsValidVersion
            );
    }
}
