using MediatR;

namespace MessageService.Application.UseCases.DeleteExpiredMessages
{
    public record DeleteExpiredMessagesRequest(int Seconds) : IRequest;
}
