namespace StudyProgramInviteService.Domain
{
    public enum SPIStateValue
    {
        CreationValidating,
        CreationValidated,
        CreationInvalidated,

        ApprovalValidating,
        ApprovalValidated,
        ApprovalInvalidated,

        Rejected,
        Approved,
    }
}
