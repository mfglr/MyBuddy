using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.UpdateCapacity
{
    internal class UpdateCapacityHandler(IUnitOfWork unitOfWork, UpdateCapacityMapper mapper, IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository, IIdentityService identityService) : IRequestHandler<UpdateCapacityRequest>
    {
        public async Task Handle(UpdateCapacityRequest request, CancellationToken cancellationToken)
        {
            var capacity = new StudyProgramCapacity(request.Capacity);

            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.UpdateCapacity(capacity);
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
