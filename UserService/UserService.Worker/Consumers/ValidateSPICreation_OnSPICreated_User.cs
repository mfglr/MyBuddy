using MassTransit;
using Shared.Events.StudyProgramService.StudyProgramInvite;
using UserService.Domain;

namespace UserService.Worker.Consumers
{
    internal static class Mapper
    {
        public static SPICreationInvalidatedEvent MapInvalidatedEvent(SPICreatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId,
                SPIInvalidationReason.UserNotFound
            );
        public static SPICreationValidatedEvent MapValidatedEvent(SPICreatedEvent @event) =>
            new(
                @event.StudyProgramId,
                @event.UserId
            );
    }

    internal class ValidateSPICreation_OnSPICreated_User(IGrainFactory grainFactory, IPublishEndpoint publishEndpoint) : IConsumer<SPICreatedEvent>
    {
        public async Task Consume(ConsumeContext<SPICreatedEvent> context)
        {
            var userGrain = grainFactory.GetGrain<IUserGrain>(context.Message.UserId);
            var user = await userGrain.Get();

            if(user == null || user.IsDeleted)
            {
                var @event = Mapper.MapInvalidatedEvent(context.Message);
                await publishEndpoint.Publish(@event);
            }
            else
            {
                var @event = Mapper.MapValidatedEvent(context.Message);
                await publishEndpoint.Publish(@event);
            }
        }
    }
}
