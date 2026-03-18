using Media.Models;

namespace MediaService.Domain
{
    public class Media
    {
        public string ContainerName { get; private set; } = null!;
        public string BlobName { get; private set; } = null!;
        public Guid OwnerId { get; private set; }
        public int Version { get; private set; } = 1;
        public MediaType Type { get; private set; }
        public Metadata? Metadata { get; private set; }
        public ModerationResult? ModerationResult { get; private set; }
        public IReadOnlyList<Thumbnail> Thumbnails { get; private set; } = [];
        public IReadOnlyList<Transcoding> Transcodings { get; private set; } = [];
        public MediaInstruction Instruction { get; private set; } = null!;

        private Media(){}

        public Media(string containerName, string blobName, Guid ownerId, MediaType type, MediaInstruction instruction)
        {
            ContainerName = containerName;
            BlobName = blobName;
            OwnerId = ownerId;
            Type = type;
            Instruction = instruction;
        }
    }
}
