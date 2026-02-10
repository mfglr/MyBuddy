using MediatR;

namespace MessageService.Aplication.UseCases.GetUnreceivedMessages
{
    public record GetUnreceivedMessagesRequest(Guid UserId) : IRequest<GetUnreceivedMessagesResponse>;
}
