using System.Net;

namespace BlobService.Infrastructure.Exceptions
{
    internal class ContainerAlreadyExistException() : Exception("A container with the same name already exists.");
}
