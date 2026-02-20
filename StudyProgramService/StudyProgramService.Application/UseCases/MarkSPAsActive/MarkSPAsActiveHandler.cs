using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramService.Application.UseCases.MarkSPAsCompleted;
using StudyProgramService.Domain.Abstracts;

namespace StudyProgramService.Application.UseCases.MarkSPAsActive
{
    internal class MarkSPAsActiveHandler(IUnitOfWork unitOfWork, IIdentityService identityService, IPublishEndpoint publishEndpoint, MarkSPAsCompletedMapper mapper, ISPRepository studyProgramRepository) : IRequestHandler<MarkSPAsActiveRequest>
    {
        public async Task Handle(MarkSPAsActiveRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new SPNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new AuthorizationException();

            studyProgram.MarkAsActive();
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
