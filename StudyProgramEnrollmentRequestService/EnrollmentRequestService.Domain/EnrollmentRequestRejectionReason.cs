namespace EnrollmentRequestService.Domain
{
    public enum EnrollmentRequestRejectionReason
    {
        StudyProgramNotFound,
        SelfEnrollment,
        StudyProgramNotFree,
        StudyProgramInactive,
        RejectedByStudyProgramOwner
    }
}
