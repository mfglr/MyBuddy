using Shared.Events.MediaService;

namespace VideoTranscoder.Application.UseCases.TranscodeVideo
{
    internal class TranscodeVideoMapper
    {
        public VideoTrascodedEvent Map(TranscodeVideoRequest request, string trascodedBlobName) =>
            new(
                request.ContainerName,
                request.BlobName,
                trascodedBlobName
            );
    }
}
