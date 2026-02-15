using MassTransit;
using MediatR;
using StudyProgramService.Application.UseCases.MarkStudyProgramAsCompleted;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsActive
{
    internal class MarkStudyProgramAsActiveHandler(IIdentityService identityService, IPublishEndpoint publishEndpoint, MarkStudyProgramAsCompletedMapper mapper, IStudyProgramRepository studyProgramRepository) : IRequestHandler<MarkStudyProgramAsActiveRequest>
    {
        public async Task Handle(MarkStudyProgramAsActiveRequest request, CancellationToken cancellationToken)
        {
            var studyProgram =
                await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.MarkAsActive();
            await studyProgramRepository.UpdateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
