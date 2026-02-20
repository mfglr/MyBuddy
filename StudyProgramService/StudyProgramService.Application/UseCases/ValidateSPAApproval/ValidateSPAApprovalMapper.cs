using Shared.Events.StudyProgramService;

namespace StudyProgramService.Application.UseCases.ValidateSPAApproval
{
    internal class ValidateSPAApprovalMapper()
    {
        public SPAApprovalValidatedEvent MapValidatedEvent(ValidateSPAApprovalRequest request) =>
            new(
                request.StudyProgramId,
                request.UserId
            );

        public SPAApprovalInvalidatedEvent MapInvalidatedEvent(ValidateSPAApprovalRequest request, SPARejectionReason rejectionReason) =>
            new(
                request.StudyProgramId,
                request.UserId,
                rejectionReason
            );
    }
}
