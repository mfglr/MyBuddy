using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaHandler(
        CreateMediaMapper mapper,
        MediaPreprocessingCompletionEvaluator mediaPreprocessingCompletionEvaluator,
        CreateMedia_MessageGenerator messageGenerator,
        IPublishEndpoint publishEndpoint,
        IMediaRepository mediaRepository
    ) : IRequestHandler<CreateMediaRequest>
    {
        public async Task Handle(CreateMediaRequest request, CancellationToken cancellationToken)
        {
            var media = request.Media.Select(x => new Media(x.ContainerName, x.BlobName, request.Id, x.Type, x.Instruction));
            await mediaRepository.CreateAsync(media, cancellationToken);

            var events = new List<object>();
            foreach (var mediaItem in media)
            {
                if (mediaPreprocessingCompletionEvaluator.IsPreprocessingCompleted(mediaItem))
                    events.Add(mapper.Map(mediaItem));
                events.AddRange(messageGenerator.GenerateMessages(mediaItem));
            }
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
