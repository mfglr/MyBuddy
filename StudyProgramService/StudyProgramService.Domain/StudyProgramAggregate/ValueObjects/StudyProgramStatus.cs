using StudyProgramService.Domain.StudyProgramAggregate.Exceptions;

namespace StudyProgramService.Domain.StudyProgramAggregate.ValueObjects
{
    public class StudyProgramStatus
    {
        private static class Values
        {
            public readonly static string Draft = "draft";
            public readonly static string Active = "active";
            public readonly static string InProgress = "in-progress";
            public readonly static string Completed = "completed";

            public static bool IsValid(string value)
            {
                string v = value.Trim().ToLower();
                return
                    v == Draft ||
                    v == Active ||
                    v == InProgress ||
                    v == Completed;
            }
        }

        public string Value { get; private set; }

        public StudyProgramStatus(string value)
        {
            if (!Values.IsValid(value))
                throw new InvalidStatusValueException();
            Value = value;
        }

        public static StudyProgramStatus Draft() => new (Values.Draft);
        public static StudyProgramStatus Active() => new(Values.Active);
        public static StudyProgramStatus InProgress() => new(Values.InProgress);
        public static StudyProgramStatus Completed() => new(Values.Completed);

        public static bool operator ==(StudyProgramStatus x, StudyProgramStatus y) => x.Value == y.Value;
        public static bool operator !=(StudyProgramStatus x, StudyProgramStatus y) => x.Value != y.Value;
    }
}
