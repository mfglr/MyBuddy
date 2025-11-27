using MassTransit;

namespace BlobService.Application.ApplicationServices.GetBlob
{
    internal class GetBlobHandler(IBlobService blobService) : IConsumer<GetBlobDto>
    {
        private readonly IBlobService _blobService = blobService;

        public async Task Consume(ConsumeContext<GetBlobDto> context)
        {
            var stream = await _blobService.ReadAsync(context.Message.ContainerName, context.Message.BlobName, context.CancellationToken);
            await context.RespondAsync(new GetBlobResponseDto(stream));
        }
    }
}
