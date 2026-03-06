using MassTransit;
using Shared.Events.StudyProgramService.StudyProgramInvite;
using UserService.Domain;

namespace UserService.Worker.Consumers.ValidateSPICreation
{
    internal class ValidateSPICreation_SPICreated_UserService(
        ValidateSPICreation_SPICreated_Mapper mapper,
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint
    ) : IConsumer<SPICreatedEvent>
    {
        public async Task Consume(ConsumeContext<SPICreatedEvent> context)
        {
            var user = await userRepository.GetByIdAsync(context.Message.UserId,context.CancellationToken);

            if(user == null || user.IsDeleted)
            {
                var @event = mapper.MapInvalidatedEvent(context.Message);
                await publishEndpoint.Publish(@event);
            }
            else
            {
                var @event = mapper.MapValidatedEvent(context.Message);
                await publishEndpoint.Publish(@event);
            }
        }
    }
}
