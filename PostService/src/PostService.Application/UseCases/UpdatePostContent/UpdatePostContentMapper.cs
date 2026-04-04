using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.UpdatePostContent
{
    internal class UpdatePostContentMapper
    {
        private PostContentUpdatedEvent_Content Map(Content content) =>
            new(
                content.Value,
                content.ModerationResult
            );
        public PostContentUpdatedEvent Map(Post post) =>
            new(
                post.Id,
                post.CreatedAt,
                post.UpdatedAt,
                post.DeletedAt,
                post.IsDeleted,
                post.Version,
                post.UserId,
                post.Content != null ? Map(post.Content) : null,
                post.Media
            );
    }
}
