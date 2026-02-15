using MediatR;

namespace StudyProgramService.Application.UseCases.UpdatePrice
{
    public record UpdatePriceRequest(Guid Id, decimal Price, string Currency) : IRequest;
}
