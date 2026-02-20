using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramService.Domain.Abstracts;

namespace StudyProgramService.Application.UseCases.MarkSPAsInProgress
{
    internal class MarkSPAsInProgressHandler(IUnitOfWork unitOfWork, IIdentityService identityService, MarkSPAsInProgressMapper mapper, IPublishEndpoint publishEndpoint, ISPRepository studyProgramRepository) : IRequestHandler<MarkSPAsInProgressRequest>
    {
        public async Task Handle(MarkSPAsInProgressRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new SPNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new AuthorizationException();

            studyProgram.MarkAsInProgress();
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
