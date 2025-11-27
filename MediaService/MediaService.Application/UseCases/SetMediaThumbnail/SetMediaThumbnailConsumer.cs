using MassTransit;
using MediaService.Domain;

namespace MediaService.Application.UseCases.SetMediaThumbnail
{
    internal class SetMediaThumbnailConsumer(IMediaRepository repository) : IConsumer<SetMediaThumbnailRequest>
    {
        private readonly IMediaRepository _repository = repository;

        public async Task Consume(ConsumeContext<SetMediaThumbnailRequest> context)
        {
            var media = (await _repository.GetByIdAsync(context.Message.Id, context.CancellationToken))!;
            var thumbnail = new Thumbnail(context.Message.BlobName, context.Message.Resulation, context.Message.IsSquare);
            media.SetThumbnail(thumbnail);
            await _repository.UdateAsync(media, context.CancellationToken);
        }
    }
}
