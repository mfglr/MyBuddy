using Shared.Events.MediaService;

namespace VideoTranscoder.Application.UseCases.TranscodeVideo
{
    internal class TranscodeVideoMapper
    {
        public VideoTrascodedEvent Map(TranscodeVideoRequest request,string blobName) =>
            new(
                request.ContainerName,
                request.BlobName,
                new (blobName,request.Instruction.Resolution)
            );
    }
}
