namespace Media.Models
{
    public class ModerationConstraints
    {
        public int? MaxSexual { get; set; }
        public int? MaxViolence { get; set; }
        public int? MaxHate { get; set; }
        public int? MaxSelfHarm { get; set; }

        public bool IsValidationRequired =>
            MaxSexual != null ||
            MaxViolence != null ||
            MaxHate != null ||
            MaxSelfHarm != null;

        public bool IsValid(ModerationResult moderationResult) =>
            MaxSexual == null || moderationResult.Sexual <= MaxSexual &&
            MaxViolence == null || moderationResult.Violence <= MaxViolence &&
            MaxHate == null || moderationResult.Hate <= MaxHate &&
            MaxSelfHarm == null || moderationResult.SelfHarm <= MaxSelfHarm;
    }
}
