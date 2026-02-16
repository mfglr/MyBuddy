using StudyProgramService.Domain.EnrollmentRequestAggregate.Exceptions;
using StudyProgramService.Domain.EnrollmentRequestAggregate.ValueObjects;

namespace StudyProgramService.Domain.EnrollmentRequestAggregate.Entities
{
    public class EnrollmentRequest(Guid studyProgramId, Guid userId)
    {
        public Guid StudyProgramId { get; private set; } = studyProgramId;
        public Guid UserId { get; private set; } = userId;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; }
        public EnrollementRequestStatus Status { get; private set; } = null!;

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            Status = EnrollementRequestStatus.PendingApproval();
        }
        public void Approve()
        {
            if (Status != EnrollementRequestStatus.PendingApproval())
                throw new InvalidEnrollementRequestStateTransitionException();
            Status = EnrollementRequestStatus.Approved();
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Reject()
        {
            if (Status != EnrollementRequestStatus.PendingApproval())
                throw new InvalidEnrollementRequestStateTransitionException();
            Status = EnrollementRequestStatus.Rejected();
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
