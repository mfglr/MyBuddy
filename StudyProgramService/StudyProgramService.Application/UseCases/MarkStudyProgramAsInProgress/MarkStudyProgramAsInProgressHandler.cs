using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsInProgress
{
    internal class MarkStudyProgramAsInprogressHandler(IIdentityService identityService, MarkStudyProgramAsInprogressMapper mapper, IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository) : IRequestHandler<MarkStudyProgramAsInProgressRequest>
    {
        public async Task Handle(MarkStudyProgramAsInProgressRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = 
                await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.MarkAsInProgress();
            await studyProgramRepository.UpdateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
