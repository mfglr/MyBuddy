using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.UpdateCapacity
{
    internal class UpdateCapacityHandler(UpdateCapacityMapper mapper, IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository, IIdentityService identityService) : IRequestHandler<UpdateCapacityRequest>
    {
        public async Task Handle(UpdateCapacityRequest request, CancellationToken cancellationToken)
        {
            var capacity = new Capacity(request.Capacity);

            var studyProgram =
                await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.UpdateCapacity(capacity);
            await studyProgramRepository.UpdateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
