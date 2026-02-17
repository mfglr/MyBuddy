namespace StudyProgramApplicationService.Domain
{
    public class StudyProgramApplication
    {
        public Guid StudyProgramId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public int Version { get; private set; }
        public bool IsDeleted { get; private set; }
        public Guid StudyProgramOwnerId { get; private set; }
        internal StudyProgramApplication(Guid studyProgramId, Guid userId, Guid studyProgramOwnerId)
        {
            if (userId == studyProgramOwnerId)
                throw new SelfStudyProgramApplicationNotAllowedException();

            StudyProgramId = studyProgramId;
            UserId = userId;
            StudyProgramOwnerId = studyProgramOwnerId;
        }
        internal void Create()
        {
            CreatedAt = DateTime.UtcNow;
            Version = 1;
            Status = StudyProgramApplicationStatus.PendingApproval;
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

        public StudyProgramApplicationStatus Status { get; private set; }
        public StudyProgramApplicationRejectionReason? RejectionReason { get; private set; }
        public bool IsValidatedByStudyProgram { get; private set; }
        public void Approve()
        {
            if (Status != StudyProgramApplicationStatus.PendingApproval)
                throw new InvalidStudyProgramApplicationStateTransitionException();

            Status = StudyProgramApplicationStatus.Approved;
            
            Version++;
            UpdatedAt = DateTime.UtcNow;
        }
        public void Reject(StudyProgramApplicationRejectionReason rejectionReason)
        {
            if (Status != StudyProgramApplicationStatus.PendingApproval)
                throw new InvalidStudyProgramApplicationStateTransitionException();

            Status = StudyProgramApplicationStatus.Rejected;
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
