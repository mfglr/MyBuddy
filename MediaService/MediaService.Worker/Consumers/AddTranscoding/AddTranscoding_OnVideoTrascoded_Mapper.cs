using MediaService.Application.UseCases.AddTranscoding;
using Shared.Events.MediaService;

namespace MediaService.Worker.Consumers.AddTranscoding
{
    internal class AddTranscoding_OnVideoTrascoded_Mapper
    {
        public AddTrascodingRequest Map(VideoTrascodedEvent @event) =>
            new(
                @event.ContainerName,
                @event.BlobName,
                @event.Transcoding
            );
    }
}
