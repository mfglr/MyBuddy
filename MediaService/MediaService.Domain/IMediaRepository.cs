namespace MediaService.Domain
{
    public interface IMediaRepository
    {
        Task<Media?> GetAsync(string containerName, string blobName, CancellationToken cancellationToken);
        Task CreateMedia(IEnumerable<Media> media,CancellationToken cancellationToken);
        void Delete(Media media);
    }
}
