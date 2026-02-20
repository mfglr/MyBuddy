namespace Shared.Events.StudyProgramService
{
    public enum SPARejectionReason
    {
        SPNotFound,
        SelfSPA,
        InviteOnlySP,
        InactiveSP,
        IncufficientSPC,
        RejectedBySPOwner
    }
}
