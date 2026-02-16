using MassTransit;
using MediatR;
using StudyProgramService.Domain;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsDraft
{
    internal class MarkStudyProgramAsDraftHandler(IUnitOfWork unitOfWork, IIdentityService identityService, IPublishEndpoint publishEndpoint, MarkStudyProgramAsDraftMapper mapper, IStudyProgramRepository studyProgramRepository) : IRequestHandler<MarkStudyProgramAsDraftRequest>
    {
        public async Task Handle(MarkStudyProgramAsDraftRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if(studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.MarkAsDraft();

            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
