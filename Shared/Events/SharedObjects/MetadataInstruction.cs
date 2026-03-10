namespace Shared.Events.SharedObjects
{
    public class MetadataInstruction
    {
        public MetadataConstraints? Constraints { get; set; }
        
        public bool IsValid(Metadata metadata) => Constraints?.IsValid(metadata) ?? true;
    }
}
