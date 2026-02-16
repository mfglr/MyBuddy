using MassTransit;
using MediatR;
using StudyProgramService.Domain;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;
using StudyProgramService.Domain.StudyProgramAggregate.ValueObjects;

namespace StudyProgramService.Application.UseCases.UpdateDescription
{
    internal class UpdateDescriptionHandler(IUnitOfWork unitOfWork, UpdateDescriptionMapper mapper, IIdentityService identityService,IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository) : IRequestHandler<UpdateDescriptionRequest>
    {
        public async Task Handle(UpdateDescriptionRequest request, CancellationToken cancellationToken)
        {
            var description = new StudyProgramDescription(request.Description);
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.UpdateDescription(description);

            await unitOfWork.CommitAsync(cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
