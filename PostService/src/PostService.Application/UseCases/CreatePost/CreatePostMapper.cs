using PostService.Domain;
using Shared.Events.PostService;

namespace PostService.Application.UseCases.CreatePost
{
    internal class CreatePostMapper
    {
        public PostCreatedEvent Map(Post post) =>
            new(
                post.Id,
                post.CreatedAt,
                post.UpdatedAt,
                post.DeletedAt,
                post.IsDeleted,
                post.Version,
                post.UserId,
                post.Content != null ? new PostCreatedEvent_Content(post.Content.Value) : null,
                post.Media
            );
    }
}
