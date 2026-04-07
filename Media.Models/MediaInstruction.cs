namespace Media.Models
{
    public class MediaInstruction
    {
        public MetadataInstruction? MetadataInstruction { get; set; }
        public ModerationInstruction? ModerationInstruction { get; set; }
        public IReadOnlyList<ThumbnailInstruction> ThumbnailInstructions { get; set; } = [];
        public IReadOnlyList<TranscodingInstruction> TranscodingInstructions { get; set; } = [];

        public bool IsValidMetadata(Metadata metadata) => MetadataInstruction?.IsValid(metadata) ?? true;
        public bool IsMetadataValidationRequired => MetadataInstruction?.IsValidationRequired ?? false;

        public bool IsValidModerationResult(ModerationResult moderationResult) => ModerationInstruction?.IsValid(moderationResult) ?? true;
        public bool IsModerationValidationRequired => ModerationInstruction?.IsValidationRequired ?? false;

        public MetadataState MetadataState =>
            MetadataInstruction == null
                ? MetadataState.ShouldNotCalculate
                : IsMetadataValidationRequired
                    ? MetadataState.ShouldCalculateAndValidate
                    : MetadataState.ShouldCalculateAndNotValidate;

        public ModerationState ModerationState =>
            ModerationInstruction == null
                ? ModerationState.ShouldNotCalculate
                : IsModerationValidationRequired
                    ? ModerationState.ShouldCalculateAndValidate
                    : ModerationState.ShouldCalculateAndNotValidate;
    }
}
