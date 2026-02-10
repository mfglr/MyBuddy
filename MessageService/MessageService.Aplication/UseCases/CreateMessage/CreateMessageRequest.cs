using MediatR;

namespace MessageService.Aplication.UseCases.CreateMessage
{
    public record CreateMessageRequest(Guid ReceiverId, string Content) : IRequest<CreateMessageResponse>;
}
