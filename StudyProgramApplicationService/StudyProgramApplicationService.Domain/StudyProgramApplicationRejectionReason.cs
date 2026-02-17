namespace StudyProgramApplicationService.Domain
{
    public enum StudyProgramApplicationRejectionReason
    {
        StudyProgramNotFound,
        SelfEnrollment,
        StudyProgramNotFree,
        StudyProgramInactive,
        RejectedByStudyProgramOwner
    }
}
