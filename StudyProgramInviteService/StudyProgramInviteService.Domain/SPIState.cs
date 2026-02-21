using Shared.Events.StudyProgramService.StudyProgramInvite;

namespace StudyProgramInviteService.Domain
{
    public class SPIState
    {
        public DateTime CreatedAt { get; private set; }
        public SPIStateValue StateValue { get; private set; }
        public SPIInvalidationReason? InvalidationReason { get; private set; }

        private SPIState(SPIStateValue stateValue, SPIInvalidationReason? invalidationReason = null)
        {
            StateValue = stateValue;
            InvalidationReason = invalidationReason;
            CreatedAt = DateTime.UtcNow;
        }

        public static SPIState CreationValidating() => new(SPIStateValue.CreationValidating);
        public static SPIState CreationValidated() => new(SPIStateValue.CreationValidated);
        public static SPIState CreationInvalidated(SPIInvalidationReason invalidationReason) => new(SPIStateValue.CreationInvalidated, invalidationReason);

        public static SPIState ApprovalValidating() => new(SPIStateValue.ApprovalValidating);
        public static SPIState ApprovalValidated() => new(SPIStateValue.ApprovalValidated);
        public static SPIState ApprovalInvalidated(SPIInvalidationReason invalidationReason) => new(SPIStateValue.ApprovalInvalidated, invalidationReason);
    }
}
