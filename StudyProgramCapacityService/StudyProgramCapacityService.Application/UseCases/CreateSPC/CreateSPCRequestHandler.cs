using MediatR;
using StudyProgramCapacityService.Application.UseCases.CreateCapacity;

namespace StudyProgramCapacityService.Application.UseCases.CreateSPC
{
    internal class CreateSPCRequestHandler(ISPCManager capacityManager) : IRequestHandler<CreateSPCRequest>
    {
        public Task Handle(CreateSPCRequest request, CancellationToken cancellationToken) =>
            capacityManager.Create(request.StudyProgramId, request.StudyProgramOwnerId, request.Capacity);
    }
}
