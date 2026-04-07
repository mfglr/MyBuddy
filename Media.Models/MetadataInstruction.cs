namespace Media.Models
{
    public class MetadataInstruction
    {
        public MetadataConstraints? Constraints { get; set; }
        
        public bool IsValid(Metadata metadata) => Constraints?.IsValid(metadata) ?? true;
        public bool IsValidationRequired => Constraints?.IsValidationRequired ?? false;
    }
}
