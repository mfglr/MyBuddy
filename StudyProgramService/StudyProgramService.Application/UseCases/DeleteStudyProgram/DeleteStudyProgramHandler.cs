using MassTransit;
using MediatR;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.DeleteStudyProgram
{
    internal class DeleteStudyProgramHandler(IIdentityService identityService, IPublishEndpoint publishEndpoint, DeleteStudyProgramMapper mapper, IStudyProgramRepository studyProgramRepository) : IRequestHandler<DeleteStudyProgramRequest>
    {
        public async Task Handle(DeleteStudyProgramRequest request, CancellationToken cancellationToken)
        {
            var studyProgram =
                await studyProgramRepository.GetByIdAsync(request.Id, cancellationToken) ??
                throw new StudyProgramNotFoundException();

            if (identityService.UserId != studyProgram.UserId)
                throw new UnauhtrizedOperationException();

            studyProgram.Delete();
            await studyProgramRepository.UpdateAsync(studyProgram, cancellationToken);

            var @event = mapper.Map(studyProgram);
            await publishEndpoint.Publish(@event, cancellationToken);
        }
    }
}
