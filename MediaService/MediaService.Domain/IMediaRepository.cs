namespace MediaService.Domain
{
    public interface IMediaRepository
    {
        Task<Media> GetByIdAsync(MediaId id, CancellationToken cancellationToken);
        Task CreateAsync(IEnumerable<Media> media, CancellationToken cancellationToken);
        Task UpdateAsync(Media media, CancellationToken cancellationToken);
        Task DeleteAsync(Media media, CancellationToken cancellationToken);
    }
}
