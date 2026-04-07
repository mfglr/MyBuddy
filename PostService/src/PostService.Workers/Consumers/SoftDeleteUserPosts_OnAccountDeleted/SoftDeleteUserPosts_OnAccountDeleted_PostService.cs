using MassTransit;
using MediatR;
using PostService.Application.UseCases.SoftDeleteUserPosts;
using Shared.Events.Account;

namespace PostService.Workers.Consumers.SoftDeleteUserPosts_OnAccountDeleted
{
    internal class SoftDeleteUserPosts_OnAccountDeleted_PostService(ISender sender) : IConsumer<AccountDeletedEvent>
    {
        public Task Consume(ConsumeContext<AccountDeletedEvent> context) =>
            sender.Send(new SoftDeleteUserPostsRequest(context.Message.Id), context.CancellationToken);
    }
}
