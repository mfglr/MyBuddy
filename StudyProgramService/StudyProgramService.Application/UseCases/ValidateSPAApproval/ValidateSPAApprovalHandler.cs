using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;
using StudyProgramService.Domain.Abstracts;
using StudyProgramService.Domain.ValueObjects;

namespace StudyProgramService.Application.UseCases.ValidateSPAApproval
{
    internal class ValidateSPAApprovalHandler(
        ValidateSPAApprovalMapper mapper,
        IPublishEndpoint publishEndpoint,
        ISPRepository studyProgramRepository
    ) : IRequestHandler<ValidateSPAApprovalRequest>
    {
        public async Task Handle(ValidateSPAApprovalRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.StudyProgramId, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
            {
                var e = mapper.MapInvalidatedEvent(request, SPARejectionReason.SPNotFound);
                await publishEndpoint.Publish(e, cancellationToken);
                return;
            }
            if (studyProgram.Status != SPStatus.Active)
            {
                var e = mapper.MapInvalidatedEvent(request, SPARejectionReason.InactiveSP);
                await publishEndpoint.Publish(e, cancellationToken);
                return;
            }

            var @event = mapper.MapValidatedEvent(request);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
