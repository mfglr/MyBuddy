using MassTransit;
using MediatR;
using Shared.Events.Account;
using UserService.Application.UseCases.CreateUser;

namespace UserService.Worker.Consumers.CreateUser
{
    internal class CreateUser_OnAccountCreated_UserService(ISender sender) : IConsumer<AccountCreatedEvent>
    {
        public Task Consume(ConsumeContext<AccountCreatedEvent> context) =>
            sender.Send(new CreateUserRequest(context.Message.Id));
    }
}
