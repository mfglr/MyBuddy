using PostQueryService.Domain.PostProjectionAggregate;

namespace PostQueryService.Application.UseCases
{
    public record PostProjectionResponse(
        string UserId,
        string? Name,
        string UserName,
        Media.Models.Media? ProfilePhoto,
        string Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        PostContent? Content,
        IEnumerable<Media.Models.Media> Media
    );
}