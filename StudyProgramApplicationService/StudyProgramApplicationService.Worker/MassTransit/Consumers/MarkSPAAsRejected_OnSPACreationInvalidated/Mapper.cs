using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsRejected;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsRejected_OnSPACreationInvalidated
{
    internal class Mapper
    {
        public MarkSPAAsRejectedRequest  Map(SPACreationInvalidatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId,
                @event.RejectionReason
            );
    }
}
