using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramService.Domain.Abstracts;

namespace StudyProgramService.Application.UseCases.MarkSPAsCompleted
{
    internal class MarkSPAsCompletedHandler(IUnitOfWork unitOfWork, IIdentityService identityService, IPublishEndpoint publishEndpoint, MarkSPAsCompletedMapper mapper, ISPRepository studyProgramRepository) : IRequestHandler<MSPAsCompletedRequest>
    {
        public async Task Handle(MSPAsCompletedRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new SPNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new AuthorizationException();

            studyProgram.MarkAsCompleted();
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
