namespace Shared.Events.SharedObjects
{
    public class MediaInstruction
    {
        public MetadataInstruction MetadataInstruction { get; private set; } = null!;
        public ModerationInstruction? ModerationInstruction { get; set; }
        public List<ThumbnailInstruction> ThumbnailInstructions { get; set; } = [];
        public TranscodingInstruction? TranscodingInstruction { get; set; }

        private MediaInstruction(){}
        
        public MediaInstruction(MetadataInstruction metadataInstruction)
        {
            MetadataInstruction = metadataInstruction;
        }
    }
}
