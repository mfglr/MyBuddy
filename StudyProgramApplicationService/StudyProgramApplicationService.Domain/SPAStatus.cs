namespace StudyProgramApplicationService.Domain
{
    public enum SPAStatus
    {
        UnderInitialValidation,
        UnderApprovalValidation,
        AwaitingCapacityReservation,
        PendingApproval,
        Approved,
        Rejected
    }
}
