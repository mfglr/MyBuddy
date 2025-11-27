using MassTransit;
using MediaService.Domain;

namespace MediaService.Application.UseCases.SetMediaMetadata
{
    internal class SetMediaMetadataConsumer(IMediaRepository mediaRepository) : IConsumer<SetMediaMetadataRequest>
    {
        private readonly IMediaRepository _mediaRepository = mediaRepository;

        public async Task Consume(ConsumeContext<SetMediaMetadataRequest> context)
        {
            var media = (await _mediaRepository.GetByIdAsync(context.Message.Id, context.CancellationToken))!;
            var metadata = new Metadata(
                context.Message.Width,
                context.Message.Height,
                context.Message.Duration
            );
            media.SetMetadata(metadata);
            await _mediaRepository.UdateAsync(media, context.CancellationToken);
        }
    }
}
