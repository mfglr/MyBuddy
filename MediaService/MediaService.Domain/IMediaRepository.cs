namespace MediaService.Domain
{
    public interface IMediaRepository
    {
        Task CreateRangeAsync(IEnumerable<Media> media, CancellationToken cancellationToken);
        Task CreateAsync(Media media, CancellationToken cancellationToken);
        Task UdateAsync(Media media, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Media?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
