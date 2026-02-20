using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;
using StudyProgramService.Domain.Abstracts;
using StudyProgramService.Domain.ValueObjects;

namespace StudyProgramService.Application.UseCases.ValidateSPACreation
{
    internal class ValidateSPACreationHandler(
        ValidateSPACreationMapper mapper,
        IPublishEndpoint publishEndpoint,
        ISPRepository studyProgramRepository
    ) : IRequestHandler<ValidateSPACreationRequest>
    {
        public async Task Handle(ValidateSPACreationRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.StudyProgramId, cancellationToken);
            if(studyProgram == null || studyProgram.IsDeleted || studyProgram.Status == SPStatus.Draft)
            {
                var e = mapper.MapInvalidatedEvent(request, SPARejectionReason.SPNotFound);
                await publishEndpoint.Publish(e, cancellationToken);
                return;
            }
            if(studyProgram.UserId == request.UserId)
            {
                var e = mapper.MapInvalidatedEvent(request, SPARejectionReason.SelfSPA);
                await publishEndpoint.Publish(e, cancellationToken);
                return;
            }
            if (studyProgram.EnrollmentStrategy == SPEnrollmentStrategy.InviteOnly())
            {
                var e = mapper.MapInvalidatedEvent(request, SPARejectionReason.InviteOnlySP);
                await publishEndpoint.Publish(e, cancellationToken);
                return;
            }
            if (studyProgram.Status != SPStatus.Active)
            {
                var e = mapper.MapInvalidatedEvent(request, SPARejectionReason.InactiveSP);
                await publishEndpoint.Publish(e, cancellationToken);
                return;
            }

            var @event = mapper.MapValidatedEvent(request, studyProgram.EnrollmentStrategy.Value);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
