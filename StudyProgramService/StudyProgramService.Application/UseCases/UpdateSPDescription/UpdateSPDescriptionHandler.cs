using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramService.Domain.Abstracts;
using StudyProgramService.Domain.ValueObjects;

namespace StudyProgramService.Application.UseCases.UpdateSPDescription
{
    internal class UpdateSPDescriptionHandler(IUnitOfWork unitOfWork, UpdateSPDescriptionMapper mapper, IIdentityService identityService,IPublishEndpoint publishEndpoint, ISPRepository studyProgramRepository) : IRequestHandler<UpdateSPDescriptionRequest>
    {
        public async Task Handle(UpdateSPDescriptionRequest request, CancellationToken cancellationToken)
        {
            var description = new SPDescription(request.Description);
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new SPNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new AuthorizationException();

            studyProgram.UpdateDescription(description);
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
