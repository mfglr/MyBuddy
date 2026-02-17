using Shared.Events.StudyProgramService.StudyProgramApplication;
using StudyProgramService.Application.UseCases.ValidateStudyApplication;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateStudyApplication_OnStudyApplicationCreated
{
    internal class ValidateStudyApplication_OnStudyApplicationCreated_Mapper
    {
        public ValidateStudyApplicationRequest Map(StudyProgramApplicationCreatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }
}
