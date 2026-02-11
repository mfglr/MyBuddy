namespace MessageService.Application.UseCases.GetMessage
{
    public record GetMessageResponse(Guid Id, DateTime CreatedAt, Guid SenderId, Guid ReceiverId, string Content);
}
