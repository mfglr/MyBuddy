using MassTransit;
using PostLikeQueryService.Shared.Model;
using Shared.Events.UserService;

namespace PostLikeQueryService.Worker.Consumers.UpsertUser_OnUserMediaSet
{
    internal class UpsertUser_OnUserMediaSet__PostLikeQueryService(
        IUserRepository repository,
        UpsertUser_OnUserMediaSet_Mapper mapper) : IConsumer<UserMediaSetEvent>
    {
        public Task Consume(ConsumeContext<UserMediaSetEvent> context) =>
            repository.UpsertAsync(mapper.Map(context.Message), context.CancellationToken);
    }
}
