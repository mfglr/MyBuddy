using RealtimeService.Domain;

namespace RealtimeService.Application
{
    public interface IMessageRouter
    {
        Task SendAsync(IEnumerable<string> contents, Connection connection, CancellationToken cancellationToken = default);
    }
}
