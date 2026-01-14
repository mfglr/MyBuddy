using AutoMapper;
using MassTransit;
using MassTransit.Mediator;
using MediaService.Application.UseCases;
using MediaService.Application.UseCases.SetMediaMetadata;
using Shared.Events.MediaService;

namespace MediaService.Workers
{
    internal class SetMediaMetadata(IMediator mediator, IPublishEndpoint publishEndpoint, IMapper mapper) : IConsumer<MediaMetadataExtractedEvent>
    {
        private readonly IMediator _mediator = mediator;
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        private readonly IMapper _mapper = mapper;

        public async Task Consume(ConsumeContext<MediaMetadataExtractedEvent> context)
        {
            var client = _mediator.CreateRequestClient<SetMediaMetadataRequest>();
            var response = await client.GetResponse<MediaResponse>(
                new SetMediaMetadataRequest(
                    context.Message.Id,
                    context.Message.Metadata
                ),
                context.CancellationToken
            );
            
            if (response.Message.IsPreprocessingCompleted)
                await _publishEndpoint.Publish(
                    _mapper.Map<MediaResponse, MediaPreprocessingCompletedEvent>(response.Message),
                    context.CancellationToken
                );
        }
    }
}
