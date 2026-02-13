using System.Text.Json.Serialization;

namespace PostLikeQueryService.Domain.UserAggregate
{
    [method: JsonConstructor]
    public record ModerationResult(int Hate, int SelfHarm, int Sexual, int Violence);
}
