using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaHandler(
        CreateMediaMapper mapper,
        IPublishEndpoint publishEndpoint,
        IMediaRepository mediaRepository
    ) : IRequestHandler<CreateMediaRequest>
    {
        public async Task Handle(CreateMediaRequest request, CancellationToken cancellationToken)
        {
            var media = request.Media.Select(x => new Media(new(x.ContainerName, x.BlobName), request.Id, x.Type, x.Instruction));
            await mediaRepository.CreateAsync(media, cancellationToken);
            
            var events = media.Select(x => mapper.Map(request.Id,x));
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
