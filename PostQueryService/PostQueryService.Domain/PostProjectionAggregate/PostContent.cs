using Media.Models;

namespace PostQueryService.Domain.PostProjectionAggregate
{
    public record PostContent(string Value, ModerationResult? ModerationResult);
}
