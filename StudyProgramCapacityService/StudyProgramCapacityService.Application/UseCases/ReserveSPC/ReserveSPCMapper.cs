using Shared.Events.StudyProgramService;

namespace StudyProgramCapacityService.Application.UseCases.ReserveSPC
{
    internal class ReserveSPCMapper
    {
        public SPCReservedEvent MapReservedEvent(ReserveSPCRequest request) =>
            new(
                request.StudyProgramId,
                request.UserId
            );

        public SPCExceededEvent MapExceededEvent(ReserveSPCRequest request) =>
            new(
                request.StudyProgramId,
                request.UserId,
                SPARejectionReason.IncufficientSPC
            );
    }
}
