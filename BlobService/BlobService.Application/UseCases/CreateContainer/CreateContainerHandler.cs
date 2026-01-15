using MediatR;

namespace BlobService.Application.UseCases.CreateContainer
{
    internal class CreateContainerHandler(IContainerService containerService) : IRequestHandler<CreateContainerRequest>
    {
        private readonly IContainerService _containerService = containerService;

        public Task Handle(CreateContainerRequest request, CancellationToken cancellationToken) =>
            _containerService.CreateAsync(request.ContainerName, cancellationToken);
    }
}
