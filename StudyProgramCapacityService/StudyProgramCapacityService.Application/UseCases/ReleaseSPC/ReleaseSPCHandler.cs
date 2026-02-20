using MediatR;

namespace StudyProgramCapacityService.Application.UseCases.ReleaseSPC
{
    internal class ReleaseSPCHandler(ISPCManager capacityManager) : IRequestHandler<ReleaseCapacityRequest>
    {
        public Task Handle(ReleaseCapacityRequest request, CancellationToken cancellationToken) =>
            capacityManager.Release(request.StudyProgramId);
    }
}
