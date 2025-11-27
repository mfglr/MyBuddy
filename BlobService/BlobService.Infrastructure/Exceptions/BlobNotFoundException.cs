namespace BlobService.Infrastructure.Exceptions
{
    internal class BlobNotFoundException() : Exception("Blob not found in the container.");
}
