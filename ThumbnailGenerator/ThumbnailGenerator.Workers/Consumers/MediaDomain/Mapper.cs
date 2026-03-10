using Shared.Events.MediaService;
using ThumbnailGenerator.Application.UseCases.GenerateThumbnail;

namespace ThumbnailGenerator.Workers.Consumers.MediaDomain
{
    internal class Mapper
    {
        public GenerateThumbnailRequest Map(GenerateThumbnailMessage message) =>
            new(
                message.ContainerName,
                message.BlobName,
                message.Instruction
            );
    }
}
