using System.Text.Json.Serialization;

namespace PostLikeQueryService.Domain.UserAggregate
{
    [method:JsonConstructor]
    public record Thumbnail(string BlobName, double Resolution, bool IsSquare);
}
