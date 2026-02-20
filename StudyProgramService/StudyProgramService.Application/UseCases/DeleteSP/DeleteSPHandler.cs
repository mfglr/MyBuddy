using MassTransit;
using MediatR;
using Shared.Exceptions;
using StudyProgramService.Domain.Abstracts;

namespace StudyProgramService.Application.UseCases.DeleteSP
{
    internal class DeleteSPHandler(IUnitOfWork unitOfWork, IIdentityService identityService, IPublishEndpoint publishEndpoint, DeleteSPMapper mapper, ISPRepository studyProgramRepository) : IRequestHandler<DeleteSPRequest>
    {
        public async Task Handle(DeleteSPRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken);
            if (studyProgram == null || studyProgram.IsDeleted)
                throw new SPNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new AuthorizationException();

            studyProgram.Delete();
            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            
        }
    }
}
