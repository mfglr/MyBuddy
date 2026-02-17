namespace StudyProgramService.Application.UseCases.ValidateStudyApplication
{
    public enum RejectionReason
    {
        StudyProgramNotFound,
        SelfEnrollment,
        StudyProgramNotFree,
        StudyProgramInactive,
        RejectedByStudyProgramOwner
    }
}
