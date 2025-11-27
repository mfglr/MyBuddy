using System.Net;

namespace BlobService.Infrastructure.Exceptions
{
    internal class ContainerNotFoundException() : Exception("The specified container was not found.");
}
