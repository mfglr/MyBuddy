using MediatR;

namespace MediaService.Application.UseCases.CreateMedia
{
    public record CreateMediaRequest(
        Guid Id,
        IEnumerable<Media.Models.Media> Media
    ) : IRequest;
}
