using Shared.Objects;

namespace PostService.Application.UseCases.DeletePostMedia
{
    public record DeletePostMediaResponse_Content(string Value, ModerationResult? ModerationResult);
    public record DeletePostMediaResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        Guid UserId,
        int Version,
        bool IsDeleted,
        DeletePostMediaResponse_Content? Content,
        IReadOnlyList<Media> Media
    );
}
