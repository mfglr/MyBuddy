using MediatR;

namespace StudyProgramCapacityService.Application.UseCases.GetSPCById
{
    public record GetSPCByIdRequest(Guid Id) : IRequest<GetSPCByIdResponse>;
}
