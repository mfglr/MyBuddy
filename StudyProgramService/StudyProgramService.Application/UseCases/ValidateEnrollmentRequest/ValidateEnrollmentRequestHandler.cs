using MassTransit;
using MediatR;
using Shared.Events.StudyProgramService.EnrollmentRequest;
using StudyProgramService.Domain.StudyProgramAggregate.Abstracts;
using StudyProgramService.Domain.StudyProgramAggregate.ValueObjects;

namespace StudyProgramService.Application.UseCases.ValidateEnrollmentRequest
{
    internal class ValidateEnrollmentRequestHandler(IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint, IStudyProgramRepository studyProgramRepository) : IRequestHandler<ValidateEnrollmentRequest_Request>
    {
        public async Task Handle(ValidateEnrollmentRequest_Request request, CancellationToken cancellationToken)
        {
            var studyProgram = await studyProgramRepository.GetByIdAsync(request.StudyProgramId, cancellationToken);

            if(studyProgram == null || studyProgram.IsDeleted || studyProgram.Status == StudyProgramStatus.Draft())
            {
                var e = new StudyProgramEnrollmentRequest_RejectedByStudyProgram_Event(
                    request.StudyProgramId,
                    request.UserId,
                    StudyProgramEnrollmentRequest_RejectionReason.StudyProgramNotFound
                );
                await publishEndpoint.Publish(e, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }
            if(studyProgram.UserId == request.UserId)
            {
                var e = new StudyProgramEnrollmentRequest_RejectedByStudyProgram_Event(
                    request.StudyProgramId,
                    request.UserId,
                    StudyProgramEnrollmentRequest_RejectionReason.SelfEnrollment
                );
                await publishEndpoint.Publish(e, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }
            if (!studyProgram.IsFree)
            {
                var e = new StudyProgramEnrollmentRequest_RejectedByStudyProgram_Event(
                    request.StudyProgramId,
                    request.UserId,
                    StudyProgramEnrollmentRequest_RejectionReason.StudyProgramNotFree
                );
                await publishEndpoint.Publish(e, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }
            if (studyProgram.Status != StudyProgramStatus.Active())
            {
                var e = new StudyProgramEnrollmentRequest_RejectedByStudyProgram_Event(
                    request.StudyProgramId,
                    request.UserId,
                    StudyProgramEnrollmentRequest_RejectionReason.StudyProgramInactive
                );
                await publishEndpoint.Publish(e, cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
                return;
            }

            var @event = new StudyProgramEnrollmentRequest_ValidationSuccessByStudyProgram_Event(
                request.StudyProgramId,
                request.UserId
            );
            await publishEndpoint.Publish(@event, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
