namespace StudyProgramService.Domain
{
    public class Status
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

        public Status(string value)
        {
            if (!Values.IsValid(value))
                throw new InvalidStatusException();
            Value = value;
        }

        public static Status Draft() => new (Values.Draft);
        public static Status Active() => new(Values.Active);
        public static Status InProgress() => new(Values.InProgress);
        public static Status Completed() => new(Values.Completed);

        public static bool operator ==(Status x, Status y) => x.Value == y.Value;
        public static bool operator !=(Status x, Status y) => x.Value != y.Value;
    }
}
