using MediatR;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsAwaitingCapacityReservation
{
    public record MarkSPAAsAwaitingCapacityReservationRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}
