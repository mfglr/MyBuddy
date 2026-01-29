using MediatR;
using Orleans;

namespace PostService.Application.UseCases.SetPostMediaMetadata
{
    internal class SetPostMediaMetadaHandler(IGrainFactory grainFactory, ) : IRequestHandler<SetPostMediaMetadataRequest>
    {
        public Task Handle(SetPostMediaMetadataRequest request, CancellationToken cancellationToken)
        {
        }
    }
}
