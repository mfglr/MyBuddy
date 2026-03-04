namespace MediaService.Domain
{
    public class MediaList(MediaListId id, IEnumerable<Media> mediaItems)
    {
        public MediaListId Id { get; private set; } = id;
        public IReadOnlyList<Media> Items { get; private set; } = [.. mediaItems];

        public bool IsPreprocessingCompleted => !Items.Any(x => !x.IsPreprocessingCompleted);
    }
}
