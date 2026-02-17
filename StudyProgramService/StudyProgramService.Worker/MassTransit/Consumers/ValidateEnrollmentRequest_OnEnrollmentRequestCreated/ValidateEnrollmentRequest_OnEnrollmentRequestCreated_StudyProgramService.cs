using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.EnrollmentRequest;

namespace StudyProgramService.Worker.MassTransit.Consumers.ValidateEnrollmentRequest_OnEnrollmentRequestCreated
{
    internal class ValidateEnrollmentRequest_OnEnrollmentRequestCreated_StudyProgramService(ValidateEnrollmentRequest_OnEnrollmentRequestCreated_Mapper mapper, ISender sender) : IConsumer<StudyProgramEnrollmentRequest_Created_Event>
    {
        public Task Consume(ConsumeContext<StudyProgramEnrollmentRequest_Created_Event> context) =>
            sender.Send(mapper.Map(context.Message), context.CancellationToken);
    }
}
