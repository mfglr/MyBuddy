using MassTransit;

namespace BlobService.Application.ApplicationServices.UploadSingleBlob
{
    internal class UploadSingleBlobHandler(IBlobService blobService) : IConsumer<UploadSingleBlobDto>
    {
        private readonly IBlobService _blobService = blobService;

        public Task Consume(ConsumeContext<UploadSingleBlobDto> context)
            => _blobService.UploadAsync(
                context.Message.Media,
                context.Message.ContainerName,
                context.Message.BlobName,
                context.CancellationToken
            );
    }
}
