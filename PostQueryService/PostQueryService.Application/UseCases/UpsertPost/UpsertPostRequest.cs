using Media.Models;
using MediatR;

namespace PostQueryService.Application.UseCases.UpsertPost
{
    public record UpsertPostRequest_Content(
        string Value,
        ModerationResult? ModerationResult
    );

    public record UpsertPostRequest(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? DeletedAt,
        bool IsDeleted,
        int Version,
        Guid UserId,
        UpsertPostRequest_Content? Content,
        IEnumerable<Media.Models.Media> Media
    ) : IRequest;
}
