using Shared.Objects;

namespace PostService.Application.UseCases.CreatePost
{
    public record CreatePostResponse_Content(string Value);
    public record CreatePostResponse(
        Guid Id,
        CreatePostResponse_Content? Content,
        IReadOnlyList<Media> Media
    );
}
