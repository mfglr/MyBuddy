using MassTransit;
using MediaService.Domain;

namespace MediaService.Application.UseCases.SetMediaTranscodedBlobName
{
    internal class SetMediaTranscodedBlobNameConsumer(IMediaRepository repository) : IConsumer<SetMediaTranscodedBlobNameRequest>
    {
        private readonly IMediaRepository _repository = repository;

        public async Task Consume(ConsumeContext<SetMediaTranscodedBlobNameRequest> context)
        {
            var media = (await _repository.GetByIdAsync(context.Message.Id, context.CancellationToken))!;
            media.SetTranscodedBlobName(context.Message.BlobName);
            await _repository.UdateAsync(media, context.CancellationToken);
        }
    }
}
