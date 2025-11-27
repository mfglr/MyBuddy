using MassTransit;

namespace VideoTranscoder.Application.UseCases.TranscodeVideo
{
    internal class TranscodeVideoConsumer(IBlobService blobService, IVideoTranscoder videoTranscoder, TempDirectoryManager tempDirectoryManager) : IConsumer<TranscodeVideoRequest>
    {
        private readonly IBlobService _blobService = blobService;
        private readonly IVideoTranscoder _videoTranscoder = videoTranscoder;
        private readonly TempDirectoryManager _tempDirectoryManager = tempDirectoryManager;

        public async Task Consume(ConsumeContext<TranscodeVideoRequest> context)
        {
            string? blobName = null;
            try
            {
                _tempDirectoryManager.Create();

                var inputStream = await _blobService.GetAsync(context.Message.ContainerName, context.Message.BlobName, context.CancellationToken);
               
                var inputPath = await _tempDirectoryManager.AddAsync(inputStream, context.CancellationToken);
                inputStream.Close();
                inputStream.Dispose();

                var trancodedBlobPath = _tempDirectoryManager.GenerateUniqPath("mp4");
                await _videoTranscoder.Transcode(inputPath, trancodedBlobPath, context.CancellationToken);

                var transcodedBlobStream = File.OpenRead(trancodedBlobPath);
                blobName = await _blobService.UploadAsync(transcodedBlobStream,context.Message.ContainerName,context.CancellationToken);
                transcodedBlobStream.Close();
                transcodedBlobStream.Dispose();

                _tempDirectoryManager.Delete();

                await context.RespondAsync(new TranscodeVideoResponse(blobName));
            }
            catch (Exception)
            {
                _tempDirectoryManager.Delete();
                if (blobName != null)
                    await _blobService.DeleteAsync(context.Message.ContainerName, blobName, context.CancellationToken);
                throw;
            }
        }
    }
}
