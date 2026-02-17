using Shared.Events.StudyProgramService.StudyProgramApplication;
using StudyProgramApplicationService.Application.UseCases.ValidateStudyProgramApplicationStudyProgram;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.MarkAsValidated_OnValidationSuccessByStudyProgram
{
    internal class MarkAsValidated_OnValidationSuccessByStudyProgram_Mapper
    {
        public ValidateStudyProgramApplicationStudyProgramRequest Map(StudyProgramApplicationValidationSuccessEvent_StudyProgramService @event) =>
            new(
                @event.StudyPromamId,
                @event.UserId
            ); 
    }
}
