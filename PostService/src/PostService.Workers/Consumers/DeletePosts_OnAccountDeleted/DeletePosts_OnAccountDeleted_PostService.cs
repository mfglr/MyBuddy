using MassTransit;
using MediatR;
using PostService.Application.UseCases.DeletePosts;
using Shared.Events.Account;

namespace PostService.Workers.Consumers.DeletePosts_OnAccountDeleted
{
    internal class DeletePosts_OnAccountDeleted_PostService(ISender sender) : IConsumer<AccountDeletedEvent>
    {
        public Task Consume(ConsumeContext<AccountDeletedEvent> context) =>
            sender.Send(new DeletePostsRequest(context.Message.Id), context.CancellationToken);
    }
}
