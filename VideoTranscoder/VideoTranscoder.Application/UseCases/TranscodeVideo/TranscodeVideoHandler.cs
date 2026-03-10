using MassTransit;
using MediatR;

namespace VideoTranscoder.Application.UseCases.TranscodeVideo
{
    internal class TranscodeVideoHandler(TranscodeVideoMapper mapper, IPublishEndpoint publishEndpoint, IBlobService blobService, IVideoTranscoder videoTranscoder, TempDirectoryManager tempDirectoryManager) : IRequestHandler<TranscodeVideoRequest>
    {
        public async Task Handle(TranscodeVideoRequest request, CancellationToken cancellationToken)
        {
            string? blobName = null;
            try
            {
                tempDirectoryManager.Create();

                string inputPath;
                using (var inputStream = await blobService.GetAsync(request.ContainerName, request.BlobName, cancellationToken))
                {
                    inputPath = await tempDirectoryManager.AddAsync(inputStream, cancellationToken);
                }

                var trancodedBlobPath = tempDirectoryManager.GenerateUniqPath("mp4");
                await videoTranscoder.Transcode(inputPath, trancodedBlobPath, request.Instruction.Resolution, cancellationToken);

                using (var transcodedBlobStream = File.OpenRead(trancodedBlobPath))
                {
                    blobName = await blobService.UploadAsync(transcodedBlobStream, request.ContainerName, cancellationToken);
                }

                tempDirectoryManager.Delete();

                var @event = mapper.Map(request, blobName);
                await publishEndpoint.Publish(@event, cancellationToken);
            }
            catch (Exception)
            {
                tempDirectoryManager.Delete();
                if (blobName != null)
                    await blobService.DeleteAsync(request.ContainerName, blobName, cancellationToken);
                throw;
            }
        }
    }
}
