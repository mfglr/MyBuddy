using MassTransit;
using Media.Models;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaHandler(
        CreateMediaMapper mapper,
        MediaProcessingCompletionEvaluator mediaProcessingCompletionEvaluator,
        CreateMedia_MessageGenerator messageGenerator,
        IPublishEndpoint publishEndpoint,
        IMediaRepository mediaRepository
    ) : IRequestHandler<CreateMediaRequest>
    {
        public async Task Handle(CreateMediaRequest request, CancellationToken cancellationToken)
        {
            var media = request.Media.Select(x => new Domain.Media(x.ContainerName, x.BlobName, request.Id, x.Context));
            await mediaRepository.CreateAsync(media, cancellationToken);

            var events = new List<object>();
            foreach (var mediaItem in media)
            {
                if (mediaProcessingCompletionEvaluator.IsProcessingCompleted(mediaItem.Context))
                    events.Add(mapper.Map(mediaItem));
                events.AddRange(messageGenerator.GenerateMessages(mediaItem));
            }
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
