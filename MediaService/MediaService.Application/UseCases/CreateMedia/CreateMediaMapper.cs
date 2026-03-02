using MediaService.Domain;
using Shared.Events.MediaService;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaMapper
    {
        public MediaCreatedEvent Map(Media media) =>
            new(
                media.ContainerName,
                media.BlobName,
                media.Type,
                media.Instruction
            );
    }
}
