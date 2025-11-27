namespace ThumbnailGenerator.Application
{
    public interface IThumbnailGenerator
    {
        Task GenerateAsync(string input, string output, double resulation, bool isSquare, CancellationToken cancellationToken);
    }
}
