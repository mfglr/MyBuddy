using MassTransit;
using MediatR;
using StudyProgramService.Domain;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsInProgress
{
    internal class MarkStudyProgramAsInprogressHandler(IUnitOfWork unitOfWork, IIdentityService identityService, MarkStudyProgramAsInprogressMapper mapper, IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository) : IRequestHandler<MarkStudyProgramAsInProgressRequest>
    {
        public async Task Handle(MarkStudyProgramAsInProgressRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.MarkAsInProgress();

            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
