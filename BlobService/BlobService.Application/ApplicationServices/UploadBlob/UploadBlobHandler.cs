using MassTransit;

namespace BlobService.Application.ApplicationServices.UploadBlob
{
    internal class UploadBlobHandler(IBlobService blobService) : IConsumer<UploadBlobDto>
    {
        private readonly IBlobService _blobService = blobService;
        public async Task Consume(ConsumeContext<UploadBlobDto> context)
        {
            var blobNames = await _blobService.UploadAsync(context.Message.ContainerName, context.Message.Media, context.CancellationToken);
            await context.RespondAsync(new UploadBlobResponseDto(blobNames));
        }
    }
}
