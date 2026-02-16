using MassTransit;
using MediatR;
using StudyProgramService.Domain;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;

namespace StudyProgramService.Application.UseCases.IncreaseEnrollmentCount
{
    internal class IncreaseEnrollmentCountHandler(IncreaseEnrollmentMapper mapper, IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository) : IRequestHandler<IncreaseEnrollmentCountRequest>
    {
        public async Task Handle(IncreaseEnrollmentCountRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            studyProgram.IncreaseEnrollmentCount();

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
