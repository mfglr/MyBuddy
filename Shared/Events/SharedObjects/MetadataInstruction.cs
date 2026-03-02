using System.Text.Json.Serialization;

namespace Shared.Events.SharedObjects
{
    public class MetadataInstruction
    {
        public double Duration { get; private set; }

        [JsonConstructor]
        public MetadataInstruction(double duration)
        {
            if (duration < 0)
                throw new InvalidMetadataInstruction();
            Duration = duration;
        }
        public bool IsValidMetadata(Metadata metadata) => metadata.Duration < Duration;
    }
}
