using MassTransit;

namespace ThumbnailGenerator.Application.UseCases.GenerateThumbnail
{
    internal class GenerateThumbnailConsumer(IThumbnailGenerator thumbnailGenerator, IBlobService blobService, TempDirectoryManager tempDirectoryManager) : IConsumer<GenerateThumbnailRequest>
    {
        private readonly IThumbnailGenerator _thumbnailGenerator = thumbnailGenerator;
        private readonly IBlobService _blobService = blobService;
        private readonly TempDirectoryManager _tempDirectoryManager = tempDirectoryManager;

        public async Task Consume(ConsumeContext<GenerateThumbnailRequest> context)
        {
            string? blobName = null;
            try
            {
                _tempDirectoryManager.Create();
                
                var inputStream = await _blobService.GetAsync(context.Message.ContainerName, context.Message.BlobName, context.CancellationToken);
                var inputPath = await _tempDirectoryManager.AddAsync(inputStream, context.CancellationToken);
                inputStream.Close();
                inputStream.Dispose();

                var outputPath = _tempDirectoryManager.GenerateUniqPath("jpeg");
                await _thumbnailGenerator.GenerateAsync(inputPath, outputPath, context.Message.Resulation, context.Message.IsSquare, context.CancellationToken);

                var fileStream = File.OpenRead(outputPath);
                blobName = await _blobService.UploadAsync(fileStream, context.Message.ContainerName, context.CancellationToken);
                fileStream.Close();
                fileStream.Dispose();

                _tempDirectoryManager.Delete();

                await context.RespondAsync(new GenerateThumbnailResponse(blobName));
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
