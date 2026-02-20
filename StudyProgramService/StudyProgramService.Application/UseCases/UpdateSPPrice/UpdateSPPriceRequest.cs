using MediatR;

namespace StudyProgramService.Application.UseCases.UpdateSPPrice
{
    public record UpdateSPPriceRequest(Guid Id, decimal Price, string Currency) : IRequest;
}
