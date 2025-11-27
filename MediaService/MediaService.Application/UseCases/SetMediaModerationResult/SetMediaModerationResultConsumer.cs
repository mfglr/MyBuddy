using MassTransit;
using MediaService.Domain;

namespace MediaService.Application.UseCases.SetMediaModerationResult
{
    internal class SetMediaModerationResultConsumer(IMediaRepository mediaRepository) : IConsumer<SetMediaModerationResultRequest>
    {
        private readonly IMediaRepository _mediaRepository = mediaRepository;

        public async Task Consume(ConsumeContext<SetMediaModerationResultRequest> context)
        {
            var media = (await _mediaRepository.GetByIdAsync(context.Message.Id, context.CancellationToken))!;
            var moderationResult = 
                new ModerationResult(
                    context.Message.Hate,
                    context.Message.SelfHarm,
                    context.Message.Sexual,
                    context.Message.Violance
                );
            media.SetModerationResult(moderationResult);
            await _mediaRepository.UdateAsync(media, context.CancellationToken);
        }
    }
}
