using MediatR;
using Shared.Objects;

namespace PostService.Application.UseCases.SetPostMediaMetadata
{
    public record SetPostMediaMetadataRequest(Guid Id, Metadata Metadata) : IRequest;
}
