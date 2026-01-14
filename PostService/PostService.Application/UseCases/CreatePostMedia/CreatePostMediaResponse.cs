using Shared.Objects;

namespace PostService.Application.UseCases.CreatePostMedia
{
    public record CreatePostMediaResponse(Guid Id, IEnumerable<Media> Media);
}
