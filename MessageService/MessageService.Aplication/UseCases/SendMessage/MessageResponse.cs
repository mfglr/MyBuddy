namespace MessageService.Aplication.UseCases.SendMessage
{
    public record MessageResponse(
        Guid Id,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        int Version,
        Guid SenderId,
        Guid ReceiverId,
        string Content,
        DateTime? ReceivedAt,
        DateTime? SeenAt
    );
}
