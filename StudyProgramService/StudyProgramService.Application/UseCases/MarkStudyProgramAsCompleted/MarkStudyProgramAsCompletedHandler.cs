using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsCompleted
{
    internal class MarkStudyProgramAsCompletedHandler(IIdentityService identityService, IPublishEndpoint publishEndpoint, MarkStudyProgramAsCompletedMapper mapper, IStudyProgramRepository studyProgramRepository) : IRequestHandler<MarkStudyProgramAsCompletedRequest>
    {
        public async Task Handle(MarkStudyProgramAsCompletedRequest request, CancellationToken cancellationToken)
        {
            var studyProgram =
                await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.MarkAsCompleted();
            await studyProgramRepository.UpdateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
