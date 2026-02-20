using StudyProgramService.Domain.Exceptions;

namespace StudyProgramService.Domain.ValueObjects
{
    public class SPEnrollmentStrategy
    {
        private class Values
        {
            public static readonly string Open = "open";
            public static readonly string ApprovalBased = "approval-based";
            public static readonly string InviteOnly = "invite-only";

            public static bool IsValid(string value) =>
                 value == Open || value == ApprovalBased || value == InviteOnly;
        }

        public string Value { get; private set; }

        public SPEnrollmentStrategy(string value)
        {
            if (!Values.IsValid(value))
                throw new InvalidSPEnrollmentStrategyValue();
            Value = value;
        }

        public static SPEnrollmentStrategy Open() => new(Values.Open);
        public static SPEnrollmentStrategy ApprovalBased() => new(Values.ApprovalBased);
        public static SPEnrollmentStrategy InviteOnly() => new(Values.InviteOnly);

        public static bool operator ==(SPEnrollmentStrategy x, SPEnrollmentStrategy y) =>
            x.Value == y.Value;
        public static bool operator !=(SPEnrollmentStrategy x, SPEnrollmentStrategy y) =>
            x.Value != y.Value;

        public override bool Equals(object? obj) =>
            obj is SPEnrollmentStrategy other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
