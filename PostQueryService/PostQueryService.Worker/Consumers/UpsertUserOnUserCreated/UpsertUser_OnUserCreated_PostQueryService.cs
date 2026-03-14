using MassTransit;
using PostQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostQueryService.Worker.Consumers.UpsertUserOnUserCreated
{
    internal class UpsertUser_OnUserCreated_PostQueryService(
        UpsertUser_OnUserCreated_Mapper mapper,
        IUserRepository userRepository
    ) : IConsumer<UserCreatedEvent>
    {
        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {

            try
            {
                await userRepository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
