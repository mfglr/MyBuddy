using MassTransit;
using MassTransit.Transports;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.UpdateDescription
{
    internal class UpdateDescriptionHandler(UpdateDescriptionMapper mapper, IIdentityService identityService,IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository) : IRequestHandler<UpdateDescriptionRequest>
    {
        public async Task Handle(UpdateDescriptionRequest request, CancellationToken cancellationToken)
        {
            var description = new Description(request.Description);
            var studyProgram =
                await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.UpdateDescription(description);
            await studyProgramRepository.UpdateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
