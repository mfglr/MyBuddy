namespace BlobService.Infrastructure.Exceptions
{
    internal class BlobNameAlreadyExistsException() : Exception("A blob with the same name already exists.");
}
