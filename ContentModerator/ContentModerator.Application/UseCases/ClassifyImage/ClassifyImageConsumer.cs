using MassTransit;

namespace ContentModerator.Application.UseCases.ClassifyImage
{
    internal class ClassifyImageConsumer(TempDirectoryManager tempDirectoryManager,IModerator moderator, IImageFrameExtractor extractor, IBlobService blobService) : IConsumer<ClassifyImageRequest>
    {
        private readonly TempDirectoryManager _tempDirectoryManager = tempDirectoryManager;
        private readonly IModerator _moderator = moderator;
        private readonly IImageFrameExtractor _extractor = extractor;
        private readonly IBlobService _blobService = blobService;

        public async Task Consume(ConsumeContext<ClassifyImageRequest> context)
        {
            try
            {
                _tempDirectoryManager.Create();

                var inputStream = await _blobService.ReadAsync(context.Message.ContainerName, context.Message.BlobName, context.CancellationToken);
                
                var inputPath = await _tempDirectoryManager.AddAsync(inputStream, context.CancellationToken);
                inputStream.Close();
                inputStream.Dispose();

                var outputPath = _tempDirectoryManager.GenerateUniqPath("jpeg");
                await _extractor.ExtractAsync(inputPath, outputPath, 240, context.CancellationToken);
                
                var result = await _moderator.ClassifyImageAsync(outputPath, context.CancellationToken);

                _tempDirectoryManager.Delete();

                await context.RespondAsync(result);
            }
            catch (Exception)
            {
                _tempDirectoryManager.Delete();
                throw;
            }
        }
    }
}
