using MassTransit;
using MediatR;
using StudyProgramService.Domain;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;
using StudyProgramService.Domain.StudyProgramAggregate.ValueObjects;

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

            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
