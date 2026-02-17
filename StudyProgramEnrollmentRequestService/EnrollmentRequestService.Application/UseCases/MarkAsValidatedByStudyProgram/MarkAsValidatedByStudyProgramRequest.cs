using MediatR;

namespace EnrollmentRequestService.Application.UseCases.MarkAsValidatedByStudyProgram
{
    public record MarkAsValidatedByStudyProgramRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}
