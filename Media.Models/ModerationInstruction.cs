namespace Media.Models
{
    public class ModerationInstruction
    {
        public double Resolution { get; set; } = 720;
        public double Fps { get; set; } = 1;
        public ModerationConstraints? Constraints { get; set; }

        public bool IsValid(ModerationResult moderationResult) => Constraints?.IsValid(moderationResult) ?? true;
    }
}
