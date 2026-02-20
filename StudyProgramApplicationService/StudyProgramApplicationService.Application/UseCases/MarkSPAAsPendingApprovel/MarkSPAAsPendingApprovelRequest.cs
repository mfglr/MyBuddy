using MediatR;

namespace StudyProgramApplicationService.Application.UseCases.MarkSPAAsPendingApprovel
{
    public record MarkSPAAsPendingApprovelRequest(Guid StudyProgramId, Guid UserId) : IRequest;
}
