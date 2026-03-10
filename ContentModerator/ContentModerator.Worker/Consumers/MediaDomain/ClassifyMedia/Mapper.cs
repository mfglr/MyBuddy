using ContentModerator.Application.UseCases.ClassifyMedia;
using Shared.Events.MediaService;

namespace ContentModerator.Worker.Consumers.MediaDomain.ClassifyMedia
{
    internal class Mapper
    {
        public ClassifyMediaRequest Map(ClassifyMediaMessage message) =>
            new (
                message.ContainerName,
                message.BlobName,
                message.Type,
                message.Instruction
            );
    }
}
