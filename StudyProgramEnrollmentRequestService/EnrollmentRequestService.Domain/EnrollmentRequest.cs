namespace EnrollmentRequestService.Domain
{
    public class EnrollmentRequest
    {
        public Guid StudyProgramId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; }
        public bool IsDeleted { get; private set; }
        public Guid StudyProgramOwnerId { get; private set; }
        internal EnrollmentRequest(Guid studyProgramId, Guid userId, Guid studyProgramOwnerId)
        {
            if (userId == studyProgramOwnerId)
                throw new SelfEnrollmentNotAllowedException();

            StudyProgramId = studyProgramId;
            UserId = userId;
            StudyProgramOwnerId = studyProgramOwnerId;
        }
        internal void Create()
        {
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            Status = EnrollementRequestStatus.PendingApproval();
            IsValidatedByStudyProgram = false;
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

        public EnrollementRequestStatus Status { get; private set; } = null!;
        public EnrollmentRequestRejectionReason? RejectionReason { get; private set; }
        public bool IsValidatedByStudyProgram { get; private set; }
        public void Approve()
        {
            if (Status != EnrollementRequestStatus.PendingApproval())
                throw new InvalidEnrollementRequestStateTransitionException();
            
            Status = EnrollementRequestStatus.Approved();
            
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Reject(EnrollmentRequestRejectionReason rejectionReason)
        {
            if (Status != EnrollementRequestStatus.PendingApproval())
                throw new InvalidEnrollementRequestStateTransitionException();
            
            Status = EnrollementRequestStatus.Rejected();
            RejectionReason = rejectionReason;

            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void MarkAsValidatedByStudyProgram()
        {
            IsValidatedByStudyProgram = true;

            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public bool IsValidated => IsValidatedByStudyProgram;
    }
}
