using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsCompleted
{
    internal class MarkStudyProgramAsCompletedHandler(IUnitOfWork unitOfWork, IIdentityService identityService, IPublishEndpoint publishEndpoint, MarkStudyProgramAsCompletedMapper mapper, IStudyProgramRepository studyProgramRepository) : IRequestHandler<MarkStudyProgramAsCompletedRequest>
    {
        public async Task Handle(MarkStudyProgramAsCompletedRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.MarkAsCompleted();
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
