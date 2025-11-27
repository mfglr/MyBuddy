using MassTransit;

namespace BlobService.Application.ApplicationServices.DeleteBlob
{
    internal class DeleteBlobHandler(IBlobService blobService) : IConsumer<DeleteBlobDto>
    {
        private readonly IBlobService _blobService = blobService;

        public Task Consume(ConsumeContext<DeleteBlobDto> context) =>
            _blobService.DeleteAsync(
                context.Message.ContainerName,
                context.Message.BlobNames,
                context.CancellationToken
            );
    }
}
