using Shared.Events;

namespace PostQueryService.Infrastructure.MsSql.QuerRepositories
{
    public record InternalPostResponse_Content(
        string Value,
        ModerationResult ModerationResult
    );
    public record InternalPostResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        InternalPostResponse_Content? Content,
        string Media,
        Guid UserId,
        string? Name,
        string UserName,
        string? ProfilePhoto
    );
}
