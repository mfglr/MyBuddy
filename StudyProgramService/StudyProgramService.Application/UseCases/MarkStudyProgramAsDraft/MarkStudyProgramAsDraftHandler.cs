using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.MarkStudyProgramAsDraft
{
    internal class MarkStudyProgramAsDraftHandler(IIdentityService identityService, IPublishEndpoint publishEndpoint, MarkStudyProgramAsDraftMapper mapper, IStudyProgramRepository studyProgramRepository) : IRequestHandler<MarkStudyProgramAsDraftRequest>
    {
        public async Task Handle(MarkStudyProgramAsDraftRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = 
                await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.MarkAsDraft();
            await studyProgramRepository.UpdateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
