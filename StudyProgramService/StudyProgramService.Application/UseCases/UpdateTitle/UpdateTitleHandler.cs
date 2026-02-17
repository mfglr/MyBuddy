using MassTransit;
using MediatR;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;
using StudyProgramService.Domain.StudyProgramAggregate.ValueObjects;

namespace StudyProgramService.Application.UseCases.UpdateTitle
{
    internal class UpdateTitleHandlerv(IUnitOfWork unitOfWork, UpdateTitleMapper mapper, IIdentityService identityService, IStudyProgramRepository studyProgramRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<UpdateTitleRequest>
    {
        public async Task Handle(UpdateTitleRequest request, CancellationToken cancellationToken)
        {
            var title = new StudyProgramTitle(request.Title);
            
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.UpdateTitle(title);
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
