using Shared.Events.StudyProgramService;
using StudyProgramApplicationService.Application.UseCases.MarkSPAAsApproved;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkSPAAsApproved_OnSPCReserved
{
    internal class Mapper
    {
        public MarkSPAAsApprovedRequest Map(SPCReservedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}
