using MediatR;

namespace StudyProgramCapacityService.Application.UseCases.DeleteSPC
{
    internal class DeleteSPCHandler(ISPCManager capacityManager) : IRequestHandler<DeleteSPCRequest>
    {
        public Task Handle(DeleteSPCRequest request, CancellationToken cancellationToken) =>
            capacityManager.Delete(request.Id);
    }
}
