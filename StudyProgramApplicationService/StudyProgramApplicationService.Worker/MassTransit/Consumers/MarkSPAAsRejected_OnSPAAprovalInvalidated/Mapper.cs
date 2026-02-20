using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsRejected;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsRejected_OnSPAAprovalInvalidated
{
    internal class Mapper
    {
        public MarkSPAAsRejectedRequest Map(SPAApprovalInvalidatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId,
                @event.RejectionReason
            );
    }
}
