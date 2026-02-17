using MassTransit;
using MediatR;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;

namespace StudyProgramService.Application.UseCases.DeleteStudyProgram
{
    internal class DeleteStudyProgramHandler(IUnitOfWork unitOfWork, IIdentityService identityService, IPublishEndpoint publishEndpoint, DeleteStudyProgramMapper mapper, IStudyProgramRepository studyProgramRepository) : IRequestHandler<DeleteStudyProgramRequest>
    {
        public async Task Handle(DeleteStudyProgramRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.Delete();
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            
        }
    }
}
