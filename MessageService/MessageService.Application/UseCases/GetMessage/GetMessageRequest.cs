using MediatR;

namespace MessageService.Application.UseCases.GetMessage
{
    public record GetMessageRequest(Guid? Cursor, int RecordsPerPage) : IRequest<IEnumerable<GetMessageResponse>>;
}
