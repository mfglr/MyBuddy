using EnrollmentRequestService.Application.UseCases.MarkAsValidatedByStudyProgram;
using Shared.Events.StudyProgramService.EnrollmentRequest;

namespace EnrollmentRequestService.Worker.MassTransit.Consumers.MarkAsValidated_OnStudyProgramValidationSuccess
{
    internal class MarkAsValidated_OnStudyProgramValidationSuccess_Mapper
    {
        public MarkAsValidatedByStudyProgramRequest Map(StudyProgramEnrollmentRequest_ValidationSuccessByStudyProgram_Event @event) =>
            new(
                @event.StudyPromamId,
                @event.UserId
            ); 
    }
}
