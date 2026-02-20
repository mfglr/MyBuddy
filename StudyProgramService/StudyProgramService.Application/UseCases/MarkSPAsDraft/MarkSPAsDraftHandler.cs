using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramService.Domain.Abstracts;

namespace StudyProgramService.Application.UseCases.MarkSPAsDraft
{
    internal class MarkSPAsDraftHandler(IUnitOfWork unitOfWork, IIdentityService identityService, IPublishEndpoint publishEndpoint, MarkSPAsDraftMapper mapper, ISPRepository studyProgramRepository) : IRequestHandler<MarkSPAsDraftRequest>
    {
        public async Task Handle(MarkSPAsDraftRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if(studyProgram == null || studyProgram.IsDeleted)
                throw new SPNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new AuthorizationException();

            studyProgram.MarkAsDraft();
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
