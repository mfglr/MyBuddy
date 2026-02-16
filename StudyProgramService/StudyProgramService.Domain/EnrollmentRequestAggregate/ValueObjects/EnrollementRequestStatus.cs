using StudyProgramService.Domain.EnrollmentRequestAggregate.Exceptions;

namespace StudyProgramService.Domain.EnrollmentRequestAggregate.ValueObjects
{
    public class EnrollementRequestStatus
    {
        private class Values
        {
            public static readonly string PendingApproval = "pending-approval";
            public static readonly string Rejected = "rejected";
            public static readonly string Approved = "approved";

            public static bool IsValid(string value)
            {
                string v = value.Trim().ToLower();
                return 
                    v == PendingApproval ||
                    v == Rejected ||
                    v == Approved;
            }
        }

        public string Value { get; private set; }

        public EnrollementRequestStatus(string value)
        {
            if(Values.IsValid(value))
                throw new InvalidEnrollmentRequestStatusValueException();
            Value = value;
        }

        public static EnrollementRequestStatus PendingApproval() => new (Values.PendingApproval);
        public static EnrollementRequestStatus Rejected() => new (Values.Rejected);
        public static EnrollementRequestStatus Approved() => new (Values.Approved);

        public static bool operator ==(EnrollementRequestStatus x, EnrollementRequestStatus y) => x.Value == y.Value;
        public static bool operator !=(EnrollementRequestStatus x, EnrollementRequestStatus y) => x.Value != y.Value;
    }
}
