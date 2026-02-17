using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.IncreaseCapacity
{
    internal class IncreaseCapacityHandler(IncreaseCapacityMapper mapper, IUnitOfWork unitOfWork, IStudyProgramRepository repository, IPublishEndpoint publishEndpoint) : IRequestHandler<IncreaseCapacityRequest>
    {
        public async Task Handle(IncreaseCapacityRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await repository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            studyProgram.IncreaseCapacity(request.Increment);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
