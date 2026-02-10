namespace MessageService.Aplication.UseCases.GetUnreceivedMessages
{
    public record GetUnreceivedMessagesResponse_Message(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        Guid SenderId,
        Guid ReceiverId,
        string Content
    );
    public record GetUnreceivedMessagesResponse(IEnumerable<GetUnreceivedMessagesResponse_Message> Messages);
}
