using System.Text.Json.Serialization;

namespace PostLikeQueryService.Domain.UserAggregate
{
    [method:JsonConstructor]
    public record Metadata(double Width, double Height, double Duration);
}
