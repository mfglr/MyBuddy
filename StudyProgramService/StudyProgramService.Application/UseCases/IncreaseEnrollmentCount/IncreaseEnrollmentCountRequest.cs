using MediatR;

namespace StudyProgramService.Application.UseCases.IncreaseEnrollmentCount
{
    internal record IncreaseEnrollmentCountRequest(Guid Id) : IRequest;
}
