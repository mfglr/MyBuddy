using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.StudyProgramApplication;
using StudyProgramService.Domain;

namespace StudyProgramService.Application.UseCases.ValidateStudyApplication
{
    internal class ValidateStudyApplicationHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository) : IRequestHandler<ValidateStudyApplicationRequest>
    {
        public async Task Handle(ValidateStudyApplicationRequest request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.StudyProgramId, cancellationToken);

            if(studyProgram == null || studyProgram.IsDeleted || studyProgram.Status == StudyProgramStatus.Draft)
            {
                var e = new StudyProgramApplicationValidationFailedEvent_StudyProgramService(
                    request.StudyProgramId,
                    request.UserId,
                    (int)RejectionReason.StudyProgramNotFound
                );
                await publishEndpoint.Publish(e, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }
            if(studyProgram.UserId == request.UserId)
            {
                var e = new StudyProgramApplicationValidationFailedEvent_StudyProgramService(
                    request.StudyProgramId,
                    request.UserId,
                    (int)RejectionReason.SelfEnrollment
                );
                await publishEndpoint.Publish(e, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }
            if (!studyProgram.IsFree)
            {
                var e = new StudyProgramApplicationValidationFailedEvent_StudyProgramService(
                    request.StudyProgramId,
                    request.UserId,
                    (int)RejectionReason.StudyProgramNotFree
                );
                await publishEndpoint.Publish(e, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }
            if (studyProgram.Status != StudyProgramStatus.Active)
            {
                var e = new StudyProgramApplicationValidationFailedEvent_StudyProgramService(
                    request.StudyProgramId,
                    request.UserId,
                    (int)RejectionReason.StudyProgramInactive
                );
                await publishEndpoint.Publish(e, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var @event = new StudyProgramApplicationValidationSuccessEvent_StudyProgramService(
                request.StudyProgramId,
                request.UserId
            );
            await publishEndpoint.Publish(@event, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
