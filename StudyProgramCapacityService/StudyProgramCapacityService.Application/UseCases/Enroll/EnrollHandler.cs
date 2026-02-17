using MassTransit;
using MediatR;
using StudyProgramCapacityService.Domain;

namespace StudyProgramCapacityService.Application.UseCases.Enroll
{
    internal class EnrollHandler(EnrollMapper mapper, IPublishEndpoint publishEndpoint, IGrainFactory grainFactory) : IRequestHandler<EnrollRequest>
    {
        public async Task Handle(EnrollRequest request, CancellationToken cancellationToken)
        {
            var grain = grainFactory.GetGrain<IStudyProgramCapacityGrain>(request.StudyProgramId);
            object @event;
            try
            {
                await grain.Enroll();
                @event = mapper.Map(request.EnrollmentRequestId);
            }
            catch (InsufficientCapacityException)
            {
                @event = mapper.MapToFailedEvent(request.EnrollmentRequestId);
            }
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
