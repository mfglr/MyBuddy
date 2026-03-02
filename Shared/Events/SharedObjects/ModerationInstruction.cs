using System.Text.Json.Serialization;

namespace Shared.Events.SharedObjects
{
    [method: JsonConstructor]
    public record ModerationInstruction(
        double Resolution,
        double Fps,
        int? MaxSexual = null,
        int? MaxViolence = null,
        int? MaxHate = null,
        int? MaxSelfHarm = null
    )
    {
        public bool IsValidModerationResult(ModerationResult moderationResult) =>
            MaxSexual == null || moderationResult.Sexual <= MaxSexual &&
            MaxViolence == null || moderationResult.Violence <= MaxViolence &&
            MaxHate == null || moderationResult.Hate <= MaxHate &&
            MaxSelfHarm == null || moderationResult.SelfHarm <= MaxSelfHarm;
    }
}
