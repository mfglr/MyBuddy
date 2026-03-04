using MediaService.Application.UseCases.SetTranscodedBlobName;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.SetTranscodedBlobName
{
    internal class Mapper
    {
        public SetTranscodedBlobNameRequest Map(VideoTrascodedEvent @event) =>
            new(
                new(@event.ContainerName, @event.BlobName),
                @event.TranscodedBlobName
            );
    }
}
