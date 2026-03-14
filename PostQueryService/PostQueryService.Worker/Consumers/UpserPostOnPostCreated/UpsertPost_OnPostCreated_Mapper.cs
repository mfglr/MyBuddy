using PostQueryService.Shared.Model;
using Shared.Events.PostService;

namespace PostQueryService.Worker.Consumers.UpserPostOnPostCreated
{
    internal class UpsertPost_OnPostCreated_Mapper
    {
        public Content Map(PostCreatedEvent_Content content) =>
            new(
                content.Value,
                null
            );
        public Media Map(PostCreatedEvent_Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                null,
                null,
                [],
                []
            );
        public Post Map(PostCreatedEvent post) =>
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
