using Media.Models;
using MediatR;

namespace PostQueryService.Application.UseCases.UpsertPost
{
    public record UpsertPostRequest_Content(
        string Value,
        ModerationResult? ModerationResult
    );

    public record UpsertPostRequest_Media(
        string ContainerName,
        string BlobName,
        MediaProcessingContext Context
    );

    public record UpsertPostRequest(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? SoftDeletedAt,
        bool IsHardDeleted,
        int Version,
        Guid UserId,
        UpsertPostRequest_Content? Content,
        IEnumerable<UpsertPostRequest_Media> Media
    ) : IRequest;
}
