namespace UserService.Domain
{
    public class Gender
    {
        private static class GenderNames
        {
            public readonly static string Unknown = "Unkown";
            public readonly static string Male = "Male";
            public readonly static string Female = "Female";
        }

        public string Value { get; private set; }

        private Gender(string value) => Value = value;

        public static Gender Unknown() => new(GenderNames.Unknown);
        public static Gender Male() => new(GenderNames.Male);
        public static Gender Female() => new(GenderNames.Female);
    }
}
