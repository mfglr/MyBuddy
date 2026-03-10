namespace Shared.Events.SharedObjects
{
    public class MetadataConstraints
    {
        public double? MinDuration { get; set; }
        public double? MaxDuration { get; set; }
        public double? MinWidth { get; set; }
        public double? MaxWidth { get; set; }
        public double? MinHeight { get; set; }
        public double? MaxHeight { get; set; }
        public double? MinAspectRatio { get; set; }
        public double? MaxAspectRatio { get; set; }

        public bool IsValid(Metadata metadata) =>
            (MinDuration == null || metadata.Duration >= MinDuration) &&
            (MaxDuration == null || metadata.Duration <= MaxDuration) &&
            (MinWidth == null || metadata.Width >= MinWidth) &&
            (MaxWidth == null || metadata.Width <= MaxWidth) &&
            (MinHeight == null || metadata.Height >= MinHeight) &&
            (MaxHeight == null || metadata.Height <= MaxHeight) &&
            (MinAspectRatio == null || metadata.AspectRatio >= MinAspectRatio) &&
            (MaxAspectRatio == null || metadata.AspectRatio <= MaxAspectRatio);


        public bool IsValidationRequired =>
            MinDuration != null ||
            MaxDuration != null ||
            MinWidth != null ||
            MaxWidth != null ||
            MinHeight != null ||
            MaxHeight != null ||
            MinAspectRatio != null ||
            MaxAspectRatio != null;

    }
}
