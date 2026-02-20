using Shared.Events.StudyProgramService;

namespace StudyProgramApplicationService.Domain
{
    public class SPA
    {
        public Guid StudyProgramId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; }
        public bool IsDeleted { get; private set; }
        public Guid StudyProgramOwnerId { get; private set; }
        public SPAStatus Status { get; private set; }
        public SPARejectionReason? RejectionReason { get; private set; }

        internal SPA(Guid studyProgramId, Guid userId, Guid studyProgramOwnerId)
        {
            if (userId == studyProgramOwnerId)
                throw new SelfSPANotAllowedException();

            StudyProgramId = studyProgramId;
            UserId = userId;
            StudyProgramOwnerId = studyProgramOwnerId;
        }
        internal void Create()
        {
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            Status = SPAStatus.UnderInitialValidation;
        }
        public void Delete()
        {
            IsDeleted = true;
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Restore()
        {
            IsDeleted = false;
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }

        public void MarkAsAwaitingCapacityReservation()
        {
            if (Status != SPAStatus.UnderInitialValidation && Status != SPAStatus.UnderApprovalValidation)
                throw new InvalidSPAStateTransitionException();

            Status = SPAStatus.AwaitingCapacityReservation;
            
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void MarkAsPendingApprovel()
        {
            if (Status != SPAStatus.UnderInitialValidation)
                throw new InvalidSPAStateTransitionException();

            Status = SPAStatus.PendingApproval;

            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void MarkAsApproved()
        {
            if (Status != SPAStatus.AwaitingCapacityReservation)
                throw new InvalidSPAStateTransitionException();

            Status = SPAStatus.Approved;
            
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void MarkAsRejected(SPARejectionReason rejectionReason)
        {
            if (Status == SPAStatus.Approved || Status == SPAStatus.Rejected)
                throw new InvalidSPAStateTransitionException();

            Status = SPAStatus.Rejected;
            RejectionReason = rejectionReason;

            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void MarkAsUnderApprovalValidation()
        {
            if (Status != SPAStatus.PendingApproval && Status != SPAStatus.Rejected)
                throw new InvalidSPAStateTransitionException();

            Status = SPAStatus.UnderApprovalValidation;
            RejectionReason = null;

            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
