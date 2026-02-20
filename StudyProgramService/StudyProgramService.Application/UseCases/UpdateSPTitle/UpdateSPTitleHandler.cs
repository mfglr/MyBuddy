using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramService.Domain.Abstracts;
using StudyProgramService.Domain.ValueObjects;

namespace StudyProgramService.Application.UseCases.UpdateSPTitle
{
    internal class UpdateTitleHandlerv(IUnitOfWork unitOfWork, UpdateSPTitleMapper mapper, IIdentityService identityService, ISPRepository studyProgramRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<UpdateSPTitleRequest>
    {
        public async Task Handle(UpdateSPTitleRequest request, CancellationToken cancellationToken)
        {
            var title = new SPTitle(request.Title);
            
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new SPNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new AuthorizationException();

            studyProgram.UpdateTitle(title);
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
