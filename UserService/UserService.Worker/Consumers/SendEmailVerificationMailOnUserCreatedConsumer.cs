using MassTransit;
using Shared.Events.UserService;
using UserService.Application;

namespace UserService.Worker.Consumers
{
    public class SendEmailVerificationMailOnUserCreatedConsumer(IAuthService authService) : IConsumer<UserCreatedEvent>
    {
        private readonly IAuthService _authService = authService;

        public Task Consume(ConsumeContext<UserCreatedEvent> context) =>
            _authService.SendEmailVerficationMailAsync(context.Message.Id, context.CancellationToken);
    }
}
