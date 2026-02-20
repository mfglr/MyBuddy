using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsRejected;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsRejected_OnSPCExceeded
{
    internal class Mapper
    {
        public MarkSPAAsRejectedRequest Map(SPCExceededEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId,
                @event.RejectionReason
            );
    }
}
