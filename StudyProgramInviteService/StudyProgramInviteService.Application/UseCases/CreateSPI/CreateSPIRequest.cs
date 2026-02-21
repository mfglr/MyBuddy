using MediatR;

namespace StudyProgramInviteService.Application.UseCases.CreateSPI
{
    public record CreateSPIRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}
