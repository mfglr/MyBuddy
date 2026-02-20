using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService;

namespace StudyProgramApplicationService.Worker.MassTransit.Consumers.UpdateSPAStatus_OnSPACreationValidated
{
    internal class UpdateSPAStatus_OnSPACreationValidated(
        Mapper mapper,
        ISender sender
    ) : IConsumer<SPACreationValidatedEvent>
    {
        public Task Consume(ConsumeContext<SPACreationValidatedEvent> context) =>
            sender
                .Send(
                    context.Message.EnrollmentStrategy == EnrollmentStrategy.Open
                        ? mapper.MapReservationRequest(context.Message)
                        : mapper.MapApprovalRequest(context.Message),
                    context.CancellationToken
                );
    }
}
