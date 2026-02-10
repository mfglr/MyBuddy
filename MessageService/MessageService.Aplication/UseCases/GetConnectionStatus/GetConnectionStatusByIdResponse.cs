namespace MessageService.Aplication.UseCases.GetConnectionStatus
{
    public record GetConnectionStatusByIdResponse(bool IsOnline, DateTime? LastConnectedAt);
}
