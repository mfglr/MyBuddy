using Shared.Objects;

namespace PostService.Application.UseCases.RestorePost
{
    public record RestorePostResponse_Content(string Value, ModerationResult? ModerationResult);
    public record RestorePostResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        int Version,
        bool IsDeleted,
        RestorePostResponse_Content? Content,
        IReadOnlyList<Media> Media
    );
}
