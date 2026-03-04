using MassTransit;
using MediaService.Domain;
using MediatR;

namespace MediaService.Application.UseCases.CreateMedia
{
    internal class CreateMediaHandler(
        CreateMediaMapper mapper,
        IPublishEndpoint publishEndpoint,
        IMediaListRepository mediaListRepository
    ) : IRequestHandler<CreateMediaRequest>
    {
        public async Task Handle(CreateMediaRequest request, CancellationToken cancellationToken)
        {
            var id = new MediaListId(request.Id, request.ContainerName);
            var mediaList = new MediaList(id, request.Media.Select(x => new Media(x.BlobName, x.Type, x.Instruction)));

            await mediaListRepository.CreateAsync(mediaList, cancellationToken);
            var events = mapper.Map(mediaList);
            await publishEndpoint.PublishBatch(events, cancellationToken);
        }
    }
}
