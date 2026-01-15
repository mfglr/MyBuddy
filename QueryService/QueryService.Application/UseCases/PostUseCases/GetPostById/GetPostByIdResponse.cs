using Shared.Objects;

namespace QueryService.Application.UseCases.PostUseCases.GetPostById
{
    public record GetPostByIdResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record GetPostByIdResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        GetPostByIdResponse_Content? Content,
        IEnumerable<Media> Media
    );
}
