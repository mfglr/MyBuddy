using MassTransit;
using MediatR;
using PostService.Application.UseCases.SoftDeleteUserPosts;
using Shared.Events.Account;

namespace PostService.Workers.Consumers.DeleteUserPosts_OnAccountDeleted
{
    internal class DeleteUserPosts_OnAccountDeleted_PostService(ISender sender) : IConsumer<AccountDeletedEvent>
    {
        public Task Consume(ConsumeContext<AccountDeletedEvent> context) =>
            sender.Send(new DeleteUserPostsRequest(context.Message.Id), context.CancellationToken);
    }
}
