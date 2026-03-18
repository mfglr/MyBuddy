namespace Media.Models
{
    public class MediaInstruction
    {
        public MetadataInstruction? MetadataInstruction { get; set; }
        public ModerationInstruction? ModerationInstruction { get; set; }
        public IReadOnlyList<ThumbnailInstruction> ThumbnailInstructions { get; set; } = [];
        public IReadOnlyList<TranscodingInstruction> TranscodingInstructions { get; set; } = [];

        public bool IsValidMetadata(Metadata metadata) => MetadataInstruction?.IsValid(metadata) ?? true;
        public bool IsValidModerationResult(ModerationResult moderationResult) => ModerationInstruction?.IsValid(moderationResult) ?? true;

        public MetadataState MetadataState =>
            MetadataInstruction == null
                ? MetadataState.ShouldNotCalculate
                : MetadataInstruction != null && MetadataInstruction.Constraints != null && MetadataInstruction.Constraints.IsValidationRequired
                    ? MetadataState.ShouldCalculateAndValidate
                    : MetadataState.ShouldCalculateAndNotValidate;

        public ModerationState ModerationState =>
            ModerationInstruction == null
                ? ModerationState.ShouldNotCalculate
                : ModerationInstruction != null && ModerationInstruction.Constraints != null && ModerationInstruction.Constraints.IsValidationRequired
                    ? ModerationState.ShouldCalculateAndValidate
                    : ModerationState.ShouldCalculateAndNotValidate;
    }
}
