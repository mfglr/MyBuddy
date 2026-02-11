namespace RealtimeService.Application.UseCases.GetConnection
{
    public record GetConnectionResponse(bool IsOnline, DateTime? LastConnectedAt);
}
