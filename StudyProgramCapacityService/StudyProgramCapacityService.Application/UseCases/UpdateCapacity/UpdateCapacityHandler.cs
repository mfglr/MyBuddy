using MediatR;
using Shared.Exceptions;

namespace StudyProgramCapacityService.Application.UseCases.UpdateCapacity
{
    internal class UpdateCapacityHandler(IIdentityService identityService, ISPCManager capacityManager) : IRequestHandler<UpdateCapacityRequest>
    {
        public async Task Handle(UpdateCapacityRequest request, CancellationToken cancellationToken)
        {
            if (request.Capacity < 0)
                throw new InvalidCapacitValueException();

            var userId = identityService.UserId;
            var capacity = await capacityManager.Get(request.StudyProgramId) ?? throw new StudyProgramCapacityNotFoundException();
            
            if (capacity.StudyProgramOwnerId != userId)
                throw new AuthorizationException();

            await capacityManager.Update(request.StudyProgramId, request.Capacity);
        }
    }
}
