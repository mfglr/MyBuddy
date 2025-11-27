using MassTransit;

namespace BlobService.Application.ApplicationServices.CreateContainer
{
    internal class CreateContainerHandler(IContainerService containerService) : IConsumer<CreateContainerDto>
    {
        private readonly IContainerService _containerService = containerService;

        public Task Consume(ConsumeContext<CreateContainerDto> context) =>
            _containerService.CreateAsync(
                context.Message.ContainerName,
                context.CancellationToken
            );
    }
}
