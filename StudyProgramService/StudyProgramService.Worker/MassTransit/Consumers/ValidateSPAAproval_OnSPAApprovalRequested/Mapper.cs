using Shared.Events.StudyProgramService;
using StudyProgramService.Application.UseCases.ValidateSPAApproval;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateSPAAproval_OnSPAApprovalRequested
{
    internal class Mapper
    {
        public ValidateSPAApprovalRequest Map(SPAApprovalRequestedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}
